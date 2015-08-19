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
        private string DataPath;

        public ElasticDictionaryDataImporter(string url, string index, string path)
        {
            this.ServerUrl = url;
            this.IndexName = index;
            this.DataPath = path;
        }

        public void Execute()
        {
            // create client connection
            var node = new Uri(ServerUrl);
            var conn = new ConnectionSettings(node);
            var client = new ElasticClient(conn);


        }
    }
}
