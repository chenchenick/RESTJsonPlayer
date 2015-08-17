using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticTools
{
    public class MyAnalyzer : AnalyzerBase
    {
        public MyAnalyzer()
        {
            Type = "myanalyzer";
        }
    }
}
