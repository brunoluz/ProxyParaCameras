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
    }
}