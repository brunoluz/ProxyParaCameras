using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProxyParaCameras2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Favicon", "favicon.ico", new { controller = "Favicon", action = "Index" });
            routes.MapRoute("Images", "Image/{camera}.jpg", new { controller = "Image", action = "Index", camera = UrlParameter.Optional });

            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{id}", 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } 
            );
        }
    }
}
