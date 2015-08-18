using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "http://localhost:9200";
            string index = "elasticdictionary";
            ElasticDictionaryInitializer e = new ElasticDictionaryInitializer(server, index);
            e.Execute();
        }
    }
}
