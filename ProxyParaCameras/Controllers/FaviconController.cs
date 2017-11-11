using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProxyParaCameras2.Controllers
{
    public class FaviconController : Controller
    {
        // GET: Favicon
        public ActionResult Index()
        {
            return base.File(@"\content\images\favicon.ico", "image/x-icon");
        }
    }
}