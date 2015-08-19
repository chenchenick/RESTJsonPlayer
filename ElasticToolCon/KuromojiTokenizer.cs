using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElasticToolCon
{
    public class KuromojiTokenizer : TokenizerBase
    {
        public KuromojiTokenizer()
        {
            Type = "kuromoji_tokenizer";
        }

        [JsonProperty("mode")]
		public string Mode { get; set; }		
    }
}
