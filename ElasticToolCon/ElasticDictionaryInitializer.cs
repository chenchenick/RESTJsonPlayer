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

        public void Execute()
        {
            // create client connection
            var node = new Uri(ServerUrl);
            var conn = new ConnectionSettings(node);
            var client = new ElasticClient(conn);

            // check index name existance
            var existenceResult = client.GetIndex(i => i.Index(IndexName));
            if (!existenceResult.ConnectionStatus.Success)
            {
                // create index
                var createResult = client.CreateIndex(i => i.Index(IndexName));
                if (!createResult.Acknowledged)
                    return;
            }

            // set analyzer
            SetAnalyzers(client);
        }

        private void SetAnalyzers(ElasticClient client)
        {
            // close index for settings update
            var closeResult = client.CloseIndex(IndexName);
            if (!closeResult.Acknowledged)
                return;

            var request = new UpdateSettingsRequest();
            request.Index = IndexName;
            request.Analysis = new AnalysisSettings();

            request.Analysis.Analyzers.Add("cnAnalyzer", new SmartCnAnalyzer());
            request.Analysis.Analyzers.Add("jpAnalyzer", new KuromojiAnalyzer());

            var updateResult = client.UpdateSettings(request);
            if (!updateResult.Acknowledged)
                return;

            // reopen index
            var openresult = client.OpenIndex(IndexName);
            if (!openresult.Acknowledged)
                return;
            var newSettings = client.GetIndexSettings(s => s.Index(IndexName));
            Console.Write(newSettings);
        }

    }
}
