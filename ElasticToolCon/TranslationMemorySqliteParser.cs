using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ElasticToolCon
{
    public class TranslationMemorySqliteParser
    {
        private string sourcePath;
        public TranslationMemorySqliteParser(string path)
        {
            sourcePath = path;
        }

        public IEnumerable<TranslationMemory> Parse()
        {
            List<TranslationMemory> result = new List<TranslationMemory>();
            string connstr = @"data source=" + sourcePath + "; Version=3;";
            using (var m_dbConnection = new SQLiteConnection(connstr))
            {
                m_dbConnection.Open();
                string sql = "select * from translation_units";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                { 
                    var tm = ReadTranslationMemory(reader);
                    result.Add(tm);
                }
            }
            return result;
        }

        private TranslationMemory ReadTranslationMemory(SQLiteDataReader reader)
        {
            TranslationMemory tm = new TranslationMemory();
            tm.tmid = reader.GetInt32(0); // tmid used for update
            tm.japanese = GetSegmentFromXml(reader.GetString(4)); // source_segment
            tm.chinese = GetSegmentFromXml(reader.GetString(6)); // target_segment
            tm.tags += reader.GetString(8) + Environment.NewLine; // user
            tm.tags += reader.GetString(9) + Environment.NewLine; // date
            tm.tmname = Path.GetFileName(this.sourcePath);
            return tm;
        }

        private string GetSegmentFromXml(string content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Segment));
            Segment xmlData = (Segment)serializer.Deserialize(new StringReader(content));
            return xmlData.Elements[0].Value;
        }
    }
}
