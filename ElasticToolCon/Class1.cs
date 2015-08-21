using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    [ElasticType(
        Name = "elasticsearchprojects"
    )]
    public class ElasticSearchProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ElasticProperty(OmitNorms = true, Index = FieldIndexOption.NotAnalyzed)]
        public string Country { get; set; }
        public string Content { get; set; }
        [ElasticProperty(Name = "loc")]
        public int LOC { get; set; }

        [ElasticProperty(Type = FieldType.GeoPoint)]
        public GeoLocation Origin { get; set; }
        public DateTime StartedOn { get; set; }


        //excuse the lame properties i needed some numerics !
        public long LongValue { get; set; }
        public float FloatValue { get; set; }
        public double DoubleValue { get; set; }

        [ElasticProperty(NumericType = NumberType.Long)]
        public int StupidIntIWantAsLong { get; set; }
    }
}
