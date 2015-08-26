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
            string server = "http://192.168.1.7:9200";
            string index = "elasticdictionary";

            //InitializeIndex(server, index);
            //ImportXmlData(server, index);
            string[] paths = new string[] {
                @"C:\Users\corsica\Dropbox\TRADOS_DATA\Translation Memories\NW_MECHANICS.sdltm",
                @"C:\Users\corsica\Dropbox\TRADOS_DATA\Translation Memories\CC_MECHANICS.sdltm",
                @"C:\Users\corsica\Dropbox\TRADOS_DATA\Translation Memories\LOCAL_MECHANICS.sdltm"
            };
            foreach (var path in paths)
                ImportSqliteData(server, index, path);
        }

        private static void InitializeIndex(string server, string index)
        {
            ElasticDictionaryInitializer e = new ElasticDictionaryInitializer(server, index);
            e.Execute();
        }

        /// <summary>
        /// used to import less than 5k tm db
        /// </summary>
        /// <param name="server"></param>
        /// <param name="index"></param>
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

        private static void ImportSqliteData(string server, string index, string path)
        {
            TranslationMemorySqliteParser e = new TranslationMemorySqliteParser(path);
            var sqliteData = e.Parse();

            ElasticDictionaryDataImporter importer = new ElasticDictionaryDataImporter(server, index);
            importer.TranslationMemories = sqliteData;
            importer.Execute();
            Console.Write(importer);
        }
    }
}
