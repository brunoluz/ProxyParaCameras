using ProxyParaCameras2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ProxyParaCameras2.Controllers
{
    public class ResetController : Controller
    {
        UrlCameraHelper urlCameraHelper;

        public ResetController()
        {
            this.urlCameraHelper = new UrlCameraHelper();
        }

        // GET: Reset
        public ActionResult Index(string camera)
        {
            string url = this.urlCameraHelper.ObterUrlDeCameraParaReset(camera);

            AuthenticatedRequest request = new AuthenticatedRequest("casa", "familiaLuz");
            string xmlstring = request.GetString(url);

            var xml = new XmlDocument();
            xml.LoadXml(xmlstring);
            var resultado = xml.SelectSingleNode("/Result");
            bool sucesso = (resultado["Success"].InnerText == "1");

            if (sucesso)
                return Content("Sucesso ao reiniciar camera " + camera);
            else
                return Content("Falha ao reiniciar camera " + camera);
        }
    }
}