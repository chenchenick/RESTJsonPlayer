using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    public class SmartCnAnalyzer : AnalyzerBase
    {
        public SmartCnAnalyzer()
            : base()
        {
            Type = "smartcn";
        }
    }
}
