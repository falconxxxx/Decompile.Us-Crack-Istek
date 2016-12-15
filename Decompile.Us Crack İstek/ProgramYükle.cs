using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Decompile.Us_Crack_İstek
{
    internal class ProgramYükle
    {
        private string site = "http://dosya.web.tr/";
        private CookieContainer cc;

        public string Yükle(string programyolu)
        {
            string sonuç = "";
            string token = TokenAl();
            RestClient rc = new RestClient(site);
            RestRequest rq = new RestRequest("a/yukle", Method.POST);
            rc.CookieContainer = cc;
            var isimparça = programyolu.Split('\\');
            rq.AddFile("local_files[]", File.ReadAllBytes(programyolu), isimparça[isimparça.Length - 1], programyolu);
            rq.AddParameter("MAX_FILE_SIZE", "536870912");
            rq.AddParameter("_token", token);
            var cevap = rc.Execute(rq);
            Match eşleşme = Regex.Match(cevap.Content, "<input type=\"text\" value=\"(.*?)\" readonly=\"readonly\" class=\"focus focusonselect\">");
            if (eşleşme.Success)
            {
                sonuç = eşleşme.Groups[1].Value;
            }
            else
            {
                sonuç = "hata";
            }
            return sonuç;
        }

        public string TokenAl()
        {
            string csrf = "";
            RestClient rc = new RestClient(site);
            RestRequest rq = new RestRequest("", Method.GET);
            IRestResponse rr = rc.Execute(rq);
            CookieAyarla(rr.Cookies);
            Regex r = new Regex("<input type=\"hidden\" name=\"_token\" value=\"(.*?)\">");
            Match m = r.Match(rr.Content);
            if (!m.Success)
            {
                csrf = "0";
            }
            else
            {
                csrf = m.Groups[1].Value;
            }
            return csrf;
        }

        public void CookieAyarla(IList<RestResponseCookie> cookies)
        {
            cc = new CookieContainer();
            foreach (var cookie in cookies)
            {
                cc.Add(new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
            }
        }
    }
}