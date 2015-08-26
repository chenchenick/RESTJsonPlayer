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
            string server = "http://192.168.1.7:9200";
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
                            .Highlight(h => h
                                .OnFields(f => f.OnField(ff => ff.japanese)
                                    )
                                )
                            );
            SetResutToTextBox(result);

        }

        private string SetResutToTextBox(ISearchResponse<TranslationMemory> result)
        {
            this.richTextBox1.Clear();
            this.richTextBox1.BackColor = Color.Black;
            this.richTextBox1.ForeColor = Color.Green;
            string resultStr = string.Empty;
            if (result == null)
                return resultStr;

            foreach (var hit in result.Hits)
            {
                var id = hit.Id;
                var highlightedStr = result.Highlights[id].First().Value.Highlights.First();
                var doc = hit.Source;
                this.richTextBox1.AppendHighlightedText(highlightedStr, Color.LightSkyBlue);
                this.richTextBox1.AppendText(Environment.NewLine);
                this.richTextBox1.AppendText(doc.chinese);
                this.richTextBox1.AppendText(Environment.NewLine);
                this.richTextBox1.AppendText("-----------------------------------------------------------------------------------------------------");
                this.richTextBox1.AppendText(Environment.NewLine);
            }

            return resultStr;
        }

    }

    public static class RichTextBoxExtensions
    {
        public static void AppendHighlightedText(this RichTextBox box, string text, Color color)
        {
            int startindex = text.IndexOf("<em>");
            if (startindex == -1)
            {
                box.AppendText(text);
                return;
            }
            string piece = text.Substring(0, startindex);
            text = text.Substring(startindex + 4);
            box.AppendText(piece);
            int endindex = text.IndexOf("</em>");
            piece = text.Substring(0, endindex);
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(piece);
            box.SelectionColor = box.ForeColor;
            text = text.Substring(endindex + 5);
            box.AppendHighlightedText(text, color);
        }
    }
}
