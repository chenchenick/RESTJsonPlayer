using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticTools
{
    public class MyTokenFilter : TokenFilterBase
    {
        public MyTokenFilter()
            : base("kuromoji_readingform")
        { 
        }

        [JsonProperty("use_romaji")]
        public bool UseRomaji { get; set; }		

    }
}
