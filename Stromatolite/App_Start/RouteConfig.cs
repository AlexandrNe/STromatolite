using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Stromatolite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product",
                url: "product/{url}/{action}",
                defaults: new { controller = "Offers", action = "Details", url = UrlParameter.Optional },
                namespaces: new string[] { "Stromatolite.Controllers" });

            routes.MapRoute(
                name: "Articles",
                url: "articles/",
                defaults: new { controller = "Articles", action = "Index" },
                namespaces: new string[] { "Stromatolite.Controllers" });

            routes.MapRoute(
                name: "Article",
                url: "article/{url}/{action}",
                defaults: new { controller = "Articles", action = "Details", url = UrlParameter.Optional },
                namespaces: new string[] { "Stromatolite.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] {"Stromatolite.Controllers"}
            );
        }
    }
}
