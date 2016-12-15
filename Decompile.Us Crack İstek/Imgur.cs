using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace Decompile.Us_Crack_İstek
{
    internal class Imgur
    {
        private string result;
        private string url;

        public void Upload(string path)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    using (Stream stream = File.Open(path, FileMode.Open))
                    {
                        Image img = Image.FromStream(stream);
                        Bitmap bitmap = new Bitmap(img);
                        MemoryStream memoryStream = new MemoryStream();
                        bitmap.Save(memoryStream, ImageFormat.Jpeg);
                        memoryStream.Position = 0L;
                        byte[] inArray = memoryStream.ToArray();
                        memoryStream.Close();
                        string value = Convert.ToBase64String(inArray);
                        NameValueCollection data = new NameValueCollection { { "image", value } };
                        webClient.Headers.Add("Authorization", "Client-ID 48c549417c3084f");
                        byte[] bytes = webClient.UploadValues("https://api.imgur.com/3/upload.xml", data);
                        this.result = Encoding.Default.GetString(bytes);
                    }
                }
            }
            catch
            {
            }
        }

        public void Get()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(this.result);
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("data");
                if (elementsByTagName.Count > 0)
                {
                    XmlNode xmlNode = elementsByTagName[0];
                    string proxyUrlFormat = xmlNode.SelectSingleNode("link").InnerText;
                    this.url = "http://zend2.com/monday3.php?u=" + HttpUtility.UrlEncode(proxyUrlFormat) + "&b=12&f=norefer";
                }
            }
            catch
            {
            }
        }

        public override string ToString()
        {
            return url;
        }
    }
}