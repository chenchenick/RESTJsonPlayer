using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ElasticToolCon;

namespace ElasticTools
{
    [TestFixture]
    public class TranlationMemorySqliteParserTest
    {
        [Test]
        public void SqliteOpen()
        {
            string path = @"‪C:\Users\chenchen\Downloads\NW_MECHANICS.sdltm";
            TranslationMemorySqliteParser e = new TranslationMemorySqliteParser(path);
            e.Parse();
        }
    }
}
