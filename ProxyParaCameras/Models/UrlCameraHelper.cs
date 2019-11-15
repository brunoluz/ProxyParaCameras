using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProxyParaCameras2.Models
{
    public class UrlCameraHelper
    {
        public string ObterUrlDeCamera(string camera)
        {
            string url = string.Empty;
            if (string.Compare(camera, "ipcam01", true) == 0)
            {
                url = "http://192.168.0.169:5111/image.jpg";
            }
            else if (string.Compare(camera, "ipcam02", true) == 0)
            {
                url = string.Format("http://192.168.0.173:5554/image/IPC02?time={0}", DateTime.Now.ToOADate().ToString().Replace(",", "").Replace(".", ""));
            }
            else if (string.Compare(camera, "ipcam05", true) == 0)
            {
                url = string.Format("http://192.168.0.173:5554/image/IPC05?time={0}", DateTime.Now.ToOADate().ToString().Replace(",", "").Replace(".", ""));
            }
            else if (string.Compare(camera, "ipcam06", true) == 0)
            {
                url = string.Format("http://192.168.0.174:5555/image/IPC06?time={0}", DateTime.Now.ToOADate().ToString().Replace(",", "").Replace(".", ""));
            }
            return url;
        }
    }
}