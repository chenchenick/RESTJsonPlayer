using System;
using NUnit.Framework;
using Elasticsearch.Net;
using Nest;
using System.Threading;
using System.Collections.Generic;
namespace ElasticTools
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void InitializeIndex()
        {
            var client = GetClient();
            var existenceResult = client.GetIndex(i => i.Index(indexName));
            if (existenceResult.ConnectionStatus.Success)
            {
                var deleteResult = client.DeleteIndex(i => i.Index(indexName));
                Assert.IsTrue(deleteResult.Acknowledged);
            }

            client.CreateIndex(i => i.Index(indexName));
            existenceResult = client.GetIndex(i => i.Index(indexName));
            Assert.IsTrue(existenceResult.ConnectionStatus.Success);
        }

        [Test]
        public void DeleteIndex()
        {
            var client = GetClient();
            var existenceResult = client.GetIndex(i => i.Index(indexName));
            if (existenceResult.ConnectionStatus.Success)
            {
                var deleteResult = client.DeleteIndex(i => i.Index(indexName));
                Assert.IsTrue(deleteResult.Acknowledged);
            }
        }

        #region ignore tests
        [Test]
        [Ignore]
        public void GetServerHealth()
        {
            var client = new ElasticsearchClient();
            var result = client.CatHealth(param => param.V(true));
            Assert.IsNotNull(result);
        }

        [Test]
        [Ignore]
        public void GetIndicesStatus()
        {
            var client = new ElasticsearchClient();
            var result = client.CatIndices(param => param.V(true));
            Assert.IsNotNull(result);
        }

        [Test]
        [Ignore]
        public void GetIndices()
        {
            var client = new ElasticsearchClient();
            var result = client.CatIndices(param => param.V(true));
            Assert.IsNotNull(result);
        }

        [Test]
        [Ignore]
        public void UpdateSettingsNumberOfReplicas()
        {
            var node = new Uri("http://localhost:9200");

            var conn = new ConnectionSettings(node);

            var client = new ElasticClient(conn);
            var crtSettings = client.GetIndexSettings(s => s.Index("test"));
            Assert.AreEqual(crtSettings.IndexSettings.NumberOfReplicas, 1);

            var request = new UpdateSettingsRequest();
            request.Index = "test";
            request.NumberOfReplicas = 2;
            var response = client.UpdateSettings(request);
            var newSettings = client.GetIndexSettings(s => s.Index("test"));
            Assert.AreEqual(newSettings.IndexSettings.NumberOfReplicas, 2);
        }
        #endregion

        public void UpdateSettingsAnalysis()
        {
            var client = GetClient();
            var closeresult = client.CloseIndex(indexName);
            Assert.IsTrue(closeresult.Acknowledged);

            var request = new UpdateSettingsRequest();
            request.Index = indexName;
            request.Analysis = new AnalysisSettings();
            //request.Analysis.Analyzers.Add("content", new CustomAnalyzer()
            //            {
            //                Tokenizer = "kuromoji_tokenizer",
            //                Filter = new List<string>() { "kuromoji_baseform" }
            //            });

            //request.Analysis.TokenFilters.Add("myfilter", new MyTokenFilter()
            //{
            //    UseRomaji = false
            //});
            request.Analysis.Analyzers.Add("cnanalyzer", new KuromojiAnalyzer());
            //request.Analysis.Analyzers.Add("cnanalyzer", new CustomAnalyzer()
            //{
            //    Tokenizer = "smartcn_tokenizer"
            //    //,Filter = new List<string>() { "kuromoji_baseform" }
            //});
            //request.Analysis.Tokenizers.Add("mytokenizer", new MyTokenizer()
            //{
            //    Mode = "search"
            //});

            var response = client.UpdateSettings(request);
            Assert.IsTrue(response.Acknowledged);
            var openresult = client.OpenIndex(indexName);
            Assert.IsTrue(openresult.Acknowledged);
        }

        [Test]
        public void TryAnalyze()
        {
            UpdateSettingsAnalysis();
            //string data = "東京スカイツリー";
            string data = "関西国際空港";
            //string data = "命令行提示太花哨，用掉太多窗口空间";
            var client = GetClient();
            var newSettings = client.GetIndexSettings(s => s.Index(indexName));
            //Assert.AreEqual(1, newSettings.IndexSettings.Analysis.Analyzers.Count);

            var result = client.Analyze(a => a
                .Index(indexName)
                .Analyzer("cnanalyzer")
                .Text(data));
            Assert.IsNotNull(result.Tokens);
        }

        private string indexName = "testindex";
        private ElasticClient eClient;
        private ElasticClient GetClient()
        {
            if (eClient == null)
            {
                var node = new Uri("http://localhost:9200");
                var conn = new ConnectionSettings(node);
                eClient = new ElasticClient(conn);
            }
            return eClient;
        }

    }
}
