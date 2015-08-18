using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticTools
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
