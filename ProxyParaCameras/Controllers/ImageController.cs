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
        UrlCameraHelper urlCameraHelper;

        public ImageController()
        {
            this.urlCameraHelper = new UrlCameraHelper();
        }

        // GET: Image
        public ActionResult Index(string camera)
        {
            base.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1.0));
            base.Response.Cache.SetValidUntilExpires(false);
            base.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            base.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            base.Response.Cache.SetNoStore();

            string url = urlCameraHelper.ObterUrlDeCamera(camera);

            AuthenticatedRequest request = new AuthenticatedRequest("casa", "familiaLuz");

            // bool precisaDeParametroParaVerImagem = urlCameraHelper.CarregarParametroParaVerImagem();


            using (Image image = request.GetImage(url))
            {
                bool escreverData;
                WriteImageOptions options = (bool.TryParse(Request.QueryString["data"], out escreverData) && escreverData) ? WriteImageOptions.Yes : WriteImageOptions.No;

                using (MemoryStream imageStream = image.WriteDateTimeAndConvertToMemoryStream(options))
                {
                    return base.File(imageStream.ToArray(), "image/jpeg");
                }
            }
        }
    }
}