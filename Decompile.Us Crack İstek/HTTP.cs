using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace Decompile.Us_Crack_�stek
{
    public class �yeBilgileri
    {
        public string quick_username { get; set; }
        public string quick_password { get; set; }
        public string quick_remember = "yes";
        public string action = "do_login";
    }

    public class HTTP
    {
        private RestClient client;
        public static CookieContainer �erez;
        public string PostKey;
        public string PostHash;
        public string siteadresi;

        public void CookieAyarla(IList<RestResponseCookie> cookies)
        {
            �erez = new CookieContainer();
            foreach (var cookie in cookies)
            {
                �erez.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            }
        }

        public bool Giri�Yap(string siteadresi, �yeBilgileri �yebilgisi)
        {
            this.siteadresi = siteadresi;
            client = new RestClient(siteadresi);
            client.FollowRedirects = false;
            var istek = new RestRequest("/member.php?action=login", Method.POST);
            istek.AddParameter("quick_username", �yebilgisi.quick_username);
            istek.AddParameter("quick_password", �yebilgisi.quick_password);
            istek.AddParameter("quick_remember", �yebilgisi.quick_remember);
            istek.AddParameter("action", �yebilgisi.action);
            var cevap = client.Execute(istek);
            if (cevap.Cookies.Count != 5)
            {
                return false;
            }
            CookieAyarla(cevap.Cookies);
            client.CookieContainer = �erez;
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

        public string KonuA�(string i�erik, string programad�)
        {
            i�erik = i�erik.Replace("[p]", "");
            i�erik = i�erik.Replace("[/p]", @"\n");

            if (PostKey == null)
            {
                KeyAl();
            }
            var istek = new RestRequest("/newthread.php?fid=7&processed=1", Method.POST);
            istek.AlwaysMultipartFormData = true;
            istek.AddParameter("my_post_key", PostKey);
            istek.AddParameter("posthash", PostHash);
            istek.AddParameter("message_new", i�erik);
            istek.AddParameter("message", i�erik);
            istek.AddParameter("numpolloptions", "2");
            istek.AddParameter("subject", programad�);
            istek.AddParameter("action", "do_newthread");
            istek.AddParameter("postoptions[subscriptionmethod]", "email");
            istek.AddParameter("tid", "0");

            return client.Execute(istek).Content;
            //return "";
        }
    }
}