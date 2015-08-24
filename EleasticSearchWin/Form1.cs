using ElasticToolCon;
using Nest;
using RESTJsonWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EleasticSearchWin
{
    public partial class Form1 : Form
    {
        private ElasticClient client;
        public Form1()
        {
            InitializeComponent();

            // create client connection
            string server = "http://localhost:9200";
            string index = "elasticdictionary";
            var node = new Uri(server);
            var conn = new ConnectionSettings(node, index);
            client = new ElasticClient(conn);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text.Trim();
            ISearchResponse<TranslationMemory> result = client.Search<TranslationMemory>(s => s
                            .From(0)
                            .Size(10)
                            //.QueryRaw(@"{""match_all"": {} }")
                            //.QueryRaw(@"{""match"": { ""japanese"": {""query"":""被覆部材""} } }")
                            .Query(q => q
                                .Match(m => m
                                    .OnField(f => f.japanese)
                                    .Query(keyword)
                                    )
                                )
                            );
            textBox2.Text = ToString(result);

        }

        private string ToString(ISearchResponse<TranslationMemory> result)
        {
            string resultStr = string.Empty;
            if (result == null)
                return resultStr;

            foreach (TranslationMemory doc in result.Documents)
            {
                resultStr += doc.japanese + Environment.NewLine;
                resultStr += doc.chinese + Environment.NewLine;
                resultStr += "***************************************" + Environment.NewLine;
            }

            return resultStr;
        }
    }
}
