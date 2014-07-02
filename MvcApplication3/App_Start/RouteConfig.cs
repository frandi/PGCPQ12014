using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Mitrais",
            //    url: "Mitrais/{action}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);

            //routes.MapRoute(
            //    name: "Mitrais2",
            //    url: "{controller|Mitrais}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "FrontPage", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new { controller = "Home", action = "FrontPage", id = UrlParameter.Optional, name = UrlParameter.Optional }
            );
        }
    }
}