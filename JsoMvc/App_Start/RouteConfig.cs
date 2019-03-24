using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JsoMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Officer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Officer", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Suspect",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Suspect", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Crime",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Crime", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "JsoCaseManager",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "JsoCaseManager", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
