using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElasticToolCon
{
    public class KuromojiRomajiTokenFilter : TokenFilterBase
    {
        public KuromojiRomajiTokenFilter()
            : base("kuromoji_readingform")
        { 
        }

        [JsonProperty("use_romaji")]
        public bool UseRomaji { get; set; }		
    }
}
