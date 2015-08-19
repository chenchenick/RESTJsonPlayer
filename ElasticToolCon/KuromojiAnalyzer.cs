using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    public class KuromojiAnalyzer : AnalyzerBase
    {
        public KuromojiAnalyzer()
            : base()
        {
            Type = "kuromoji";
        }

    }
}
