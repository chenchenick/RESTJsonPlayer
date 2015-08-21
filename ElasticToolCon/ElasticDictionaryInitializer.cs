using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    public class ElasticDictionaryInitializer
    {
        private string ServerUrl;
        private string IndexName;

        public ElasticDictionaryInitializer(string url, string index)
        {
            this.ServerUrl = url;
            this.IndexName = index;
        }

        public IResponse Execute()
        {
            // create client connection
            var node = new Uri(ServerUrl);
            var conn = new ConnectionSettings(node, this.IndexName);
            var client = new ElasticClient(conn);

            // check index name existance
            var existenceResult = client.GetIndex(i => i.Index(IndexName));
            if (existenceResult.ConnectionStatus.Success)
            {
                // delete exist index
                var deleteResult = client.DeleteIndex(i => i.Index(IndexName));
                if (!deleteResult.Acknowledged)
                    return deleteResult;
            }

            // create index
            var createResult = client.CreateIndex(i => i.Index(IndexName));
            if (!createResult.Acknowledged)
                return createResult;

            // set analyzer
            SetAnalyzers(client);

            // put mapping
            var putResult = client.Map<TranslationMemory>(m => m.Index(this.IndexName).MapFromAttributes());
            //var putResult = client.Map<ElasticSearchProject>(m => m.Index(this.IndexName));
            return putResult;
        }

        private IResponse SetAnalyzers(ElasticClient client)
        {
            // close index for settings update
            var closeResult = client.CloseIndex(IndexName);
            if (!closeResult.Acknowledged)
                return closeResult;

            var request = new UpdateSettingsRequest();
            request.Index = IndexName;
            request.Analysis = new AnalysisSettings();

            request.Analysis.Analyzers.Add("cnanalyzer", new SmartCnAnalyzer());
            request.Analysis.Analyzers.Add("jpanalyzer", new KuromojiAnalyzer());

            var updateResult = client.UpdateSettings(request);
            if (!updateResult.Acknowledged)
                return updateResult;

            // reopen index
            var openresult = client.OpenIndex(IndexName);
            if (!openresult.Acknowledged)
                return openresult;
            var newSettings = client.GetIndexSettings(s => s.Index(IndexName));
            return newSettings;
        }

    }
}
