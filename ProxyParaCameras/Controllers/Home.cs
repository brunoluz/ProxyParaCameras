using ProxyParaCameras.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProxyParaCameras2.Controllers
{
    public class HomeController : Controller
    {
        ProxySettings settings;

        public HomeController() { 
            settings = new ProxySettings();
        } 

        public ActionResult Index()
        {
            ViewBag.Cameras = settings.cameras;
            return View();
        }
    }
}