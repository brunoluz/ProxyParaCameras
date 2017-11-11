using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace ProxyParaCameras2.Models
{
    public class AuthenticatedRequest
    {
        private readonly string pass;
        private readonly string user;

        // Methods
        public AuthenticatedRequest(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
        }

        public Image GetImage(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AllowWriteStreamBuffering = true;
            request.Credentials = new NetworkCredential(this.user, this.pass);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }

        internal string GetString(string url)
        {
            string retorno;

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Uri(url), new Cookie("bRememberMe", "1"));
            cookieContainer.Add(new Uri(url), new Cookie("userLastLogin", user));
            cookieContainer.Add(new Uri(url), new Cookie("passwordLastLogin", user));
            cookieContainer.Add(new Uri(url), new Cookie("user", user));
            cookieContainer.Add(new Uri(url), new Cookie("password", pass));
            cookieContainer.Add(new Uri(url), new Cookie("pwd", pass));
            cookieContainer.Add(new Uri(url), new Cookie("usrLevel", "0"));
            cookieContainer.Add(new Uri(url), new Cookie("bShowMenu", "1"));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookieContainer;
            request.AllowWriteStreamBuffering = true;
            request.Credentials = new NetworkCredential(this.user, this.pass);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    retorno = sr.ReadToEnd();
                }
            }

            return retorno;
        }
    }
}