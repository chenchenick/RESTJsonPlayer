using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTJsonWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _ServerTxt.Text = "http://192.168.16.202:9200";

            string[] methodData = new string[] { "GET", "PUT", "POST", "DELETE", "HEAD" };
            _MethodCbx.DataSource = methodData;
        }

        private void _GoBtn_Click(object sender, EventArgs e)
        {
            switch (_MethodCbx.SelectedItem.ToString())
            {
                case "GET":
                    _ResponseTxt.Text = Get();
                    break;
            }
        }

        private string Get()
        {
            using (var client = new WebClient())
            {
                Uri serverUri = new Uri(_ServerTxt.Text.Trim());
                Uri desUri = new Uri(serverUri, _PathTxt.Text);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(desUri);
                request.Method = "GET";
                String result = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
