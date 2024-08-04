using ProxyParaCameras.Models.Settings;
using ProxyParaCameras2.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProxyParaCameras2.Controllers
{
    public class ImageController : Controller
    {
        ProxySettings settings;

        public ImageController()
        {
            this.settings = new ProxySettings();
        }

        // GET: Image
        public ActionResult Index(string camera)
        {
            base.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1.0));
            base.Response.Cache.SetValidUntilExpires(false);
            base.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            base.Response.Cache.SetNoStore();

            //string url = urlCameraHelper.ObterUrlDeCamera(camera);

            AuthenticatedRequest request = new AuthenticatedRequest(settings.User, settings.Password);
            Camera camerasetting = settings.cameras.Where(x => string.Equals(x.Name, camera, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            using (Image image = request.GetImage(camerasetting.Url))
            {
                using (MemoryStream imageStream = image.WriteImageToMemoryStream())
                {
                    return base.File(imageStream.ToArray(), "image/jpeg");
                }
            }
        }
    }
}