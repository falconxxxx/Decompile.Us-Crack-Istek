using System.Net;

namespace Decompile.Us_Crack_Ýstek
{
    public abstract class Forum
    {
        private string _defaultCookieName;
        private string _defaultCookieSearch;
        private string _logindata;
        private string _loginUrl;
        private string _url;
        private string _username;

        public string defaultCookieName
        {
            get
            {
                return this._defaultCookieName;
            }
            set
            {
                this._defaultCookieName = value;
            }
        }

        public string defaultCookieSearch
        {
            get
            {
                return this._defaultCookieSearch;
            }
            set
            {
                this._defaultCookieSearch = value;
            }
        }

        public string logindata
        {
            get
            {
                return this._logindata;
            }
            set
            {
                this._logindata = value;
            }
        }

        public string loginUrl
        {
            get
            {
                return this._loginUrl;
            }
            set
            {
                this._loginUrl = value;
            }
        }

        public string url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
            }
        }

        public string username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public Forum(string url, string loginUrl, string username, string cookieName, string cookieSearch, string data = "")
        {
            this._url = url;
            this.loginUrl = loginUrl;
            this.logindata = data;
            this.username = username;
            this._defaultCookieName = cookieName;
            this._defaultCookieSearch = cookieSearch;
        }

        public abstract bool isLoggedIn(CookieContainer cookies);
    }
}