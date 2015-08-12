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
            string result = string.Empty;
            switch (_MethodCbx.SelectedItem.ToString())
            {
                case "GET":
                    result = Get();
                    break;
                case "PUT":
                    result = Put();
                    break;
                case "POST":
                    result = Post();
                    break;
                case "DELETE":
                    result = Delete();
                    break;
                case "HEAD":
                    result = Head();
                    break;
            }

            _ResponseTxt.Text = JsonHelper.FormatJson(result);
        }

        private string Post()
        {
            throw new NotImplementedException();
        }

        private string Head()
        {
            using (var client = new WebClient())
            {
                Uri serverUri = new Uri(_ServerTxt.Text.Trim());
                Uri desUri = new Uri(serverUri, _PathTxt.Text.Trim());
                string data = _BodyTxt.Text.Trim();
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(desUri);
                request.Method = "HEAD";
                return client.UploadStringWithoutException(desUri, "HEAD", data);
            }
        }

        private string Delete()
        {
            using (var client = new WebClient())
            {
                Uri serverUri = new Uri(_ServerTxt.Text.Trim());
                Uri desUri = new Uri(serverUri, _PathTxt.Text.Trim());
                string data = _BodyTxt.Text.Trim();
                return client.UploadStringWithoutException(desUri, "DELETE", data);
            }
        }

        private string Put()
        {
            using (var client = new WebClient())
            {
                Uri serverUri = new Uri(_ServerTxt.Text.Trim());
                Uri desUri = new Uri(serverUri, _PathTxt.Text.Trim());
                string data = _BodyTxt.Text.Trim();
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(desUri);
                request.Method = "PUT";
                return client.UploadStringWithoutException(desUri, "PUT", data);
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
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponseWithoutException())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }

    public static class WebRequestExtensions
    {
        public static WebResponse GetResponseWithoutException(this WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                return request.GetResponse();
            }
            catch (WebException e)
            {
                return e.Response;
            }
        }

        public static string UploadStringWithoutException(this WebClient client, Uri uri, string method, string data)
        {
            if (client == null)
            {
                throw new ArgumentNullException("webclient");
            }

            try
            {
                return client.UploadString(uri, method, data);
            }
            catch (WebException e)
            {
                return new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
