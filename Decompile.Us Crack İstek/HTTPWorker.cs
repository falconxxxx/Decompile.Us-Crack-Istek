using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Decompile.Us_Crack_Ýstek
{
    public class ÜyeBilgileri
    {
        public string quick_username { get; set; }
        public string quick_password { get; set; }
        public string quick_remember = "yes";
        public string action = "do_login";
    }

    public class HTTPWorker
    {
        private RestClient client;
        public static CookieContainer çerez;
        public string PostKey;
        public string PostHash;
        public string siteadresi;

        public void CookieAyarla(IList<RestResponseCookie> cookies)
        {
            çerez = new CookieContainer();
            foreach (var cookie in cookies)
            {
                çerez.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            }
        }

        public bool GiriþYap(string siteadresi, ÜyeBilgileri üyebilgisi)
        {
            this.siteadresi = siteadresi;
            client = new RestClient(siteadresi);
            client.FollowRedirects = false;
            var istek = new RestRequest("/member.php?action=login", Method.POST);
            istek.AddParameter("quick_username", üyebilgisi.quick_username);
            istek.AddParameter("quick_password", üyebilgisi.quick_password);
            istek.AddParameter("quick_remember", üyebilgisi.quick_remember);
            istek.AddParameter("action", üyebilgisi.action);
            var cevap = client.Execute(istek);
            if (cevap.Cookies.Count != 5)
            {
                return false;
            }
            CookieAyarla(cevap.Cookies);
            client.CookieContainer = çerez;
            return true;
        }

        public void KeyAl()
        {
            var istek = new RestRequest("/newthread.php?fid=7", Method.GET);
            var cevap = client.Execute(istek);
            if (cevap.Content.ToString().Contains("my_post_key"))
            {
                Match match = new Regex("name=\"my_post_key\" value=\"(.*?)\"").Match(cevap.Content.ToString());
                Match match2 = new Regex("name=\"posthash\" value=\"(.*?)\"").Match(cevap.Content.ToString());
                this.PostKey = match.Groups[1].Value;
                this.PostHash = match.Groups[1].Value;
            }
        }

        public string YolAl(string adres)
        {
            var istek = new RestRequest(adres, Method.GET);
            return client.Execute(istek).Content.ToString();
        }

        public string OnIzleme(string taslak, string programadý)
        {
            /*
            if(PostKey == null)
            {
                KeyAl();
            }
            var istek = new RestRequest("/newthread.php?fid=7&processed=1", Method.POST);
            istek.AlwaysMultipartFormData = true;
            istek.AddParameter("my_post_key", PostKey);
            istek.AddParameter("posthash", PostHash);
            istek.AddParameter("message_new", "123456");
            istek.AddParameter("message", "123456");
            istek.AddParameter("numpolloptions", "2");
            istek.AddParameter("subject", "123456");
            istek.AddParameter("action", "do_newthread");
            istek.AddParameter("postoptions[subscriptionmethod]", "email");
            istek.AddParameter("previewpost", "Önizleme Yap");
            istek.AddParameter("tid", "0");

            return client.Execute(istek).Content.ToString().Replace("<head>", "<head>\n<base href=\"http://www.decompile.us/\" />");
            */
            return taslak;
        }
    }
}