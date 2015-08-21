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

            //InitializeIndex(server, index);
            ImportXmlData(server, index);
        }

        private static void ImportXmlData(string server, string index)
        {
            string path = @"C:\Users\chenchen\Downloads\NW_MECHANICS_00000_0000.xml";
            TranslationMemoryXmlParser e = new TranslationMemoryXmlParser(path);
            var xmlData = e.Parse();

            ElasticDictionaryDataImporter importer = new ElasticDictionaryDataImporter(server, index);
            importer.TranslationMemories = xmlData;
            importer.Execute();
            Console.Write(importer);
        }

        private static void InitializeIndex(string server, string index)
        {
            ElasticDictionaryInitializer e = new ElasticDictionaryInitializer(server, index);
            e.Execute();
        }
    }
}
