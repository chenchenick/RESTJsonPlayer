using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticToolCon
{
    public class TranslationPieceType
    {
        public TranslationPieceType()
        {
            tags = new List<string>();
        }
        public string Id { get; set; }
        public string Japanese { get; set; }
        public string Chinese { get; set; }
        public List<string> tags { get; set; }
    }
}
