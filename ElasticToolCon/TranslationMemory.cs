using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    [ElasticType(
        Name = "translationmemory", IdProperty = "id")] 
    public class TranslationMemory
    {
        [ElasticProperty(Type = FieldType.Integer)]
        public int id { get; set; }
        [ElasticProperty(Type = FieldType.String, Analyzer = "jpanalyzer")]
        public string japanese { get; set; }
        [ElasticProperty(Type = FieldType.String, Analyzer = "cnanalyzer")]
        public string chinese { get; set; }
        [ElasticProperty(Type = FieldType.String)]
        public string tags { get; set; }
    }
}
