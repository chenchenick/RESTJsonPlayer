using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticTools
{
    public class MyTokenizer : TokenizerBase
    {
        public MyTokenizer()
        {
            Type = "kuromoji_tokenizer";
        }

        [JsonProperty("mode")]
		public string Mode { get; set; }		
    }
}
