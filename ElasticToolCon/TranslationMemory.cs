using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    [ElasticType(
        Name = "translationmemory")] 
    public class TranslationMemory
    {
        [ElasticProperty(Type = FieldType.String, Analyzer = "jpanalyzer")]
        public string japanese { get; set; }
        [ElasticProperty(Type = FieldType.String, Analyzer = "cnanalyzer")]
        public string chinese { get; set; }
        [ElasticProperty(Type = FieldType.String)]
        public string tags { get; set; }
        [ElasticProperty(Type = FieldType.Integer)]
        public int tmid { get; set; }
        [ElasticProperty(Type = FieldType.String)]
        public string tmname { get; set; }
    }
}
