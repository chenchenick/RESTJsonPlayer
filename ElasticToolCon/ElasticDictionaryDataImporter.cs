using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    public class ElasticDictionaryDataImporter
    {
        private string ServerUrl;
        private string IndexName;
        public IEnumerable<TranslationMemory> TranslationMemories { get; set; }

        public ElasticDictionaryDataImporter(string url, string index)
        {
            this.ServerUrl = url;
            this.IndexName = index;
        }

        public void Execute()
        {
            if (TranslationMemories == null)
                throw new ArgumentNullException("No data to import, please set TranslationMemories property first.");

            // create client connection
            var node = new Uri(ServerUrl);
            var conn = new ConnectionSettings(node, this.IndexName);
            var client = new ElasticClient(conn);

            foreach (TranslationMemory tm in TranslationMemories)
            {
                var indexResult = client.Index(tm);
                Console.Write(indexResult);
            }
        }
    }
}
