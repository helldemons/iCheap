using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iCheap.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "CategoryDetail",
               url: "danh-muc/{id}/{url}",
               defaults: new { controller = "Category", action = "CategoryDetail", id = UrlParameter.Optional, url = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ProductDetail",
               url: "san-pham/{id}/{url}",
               defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional, url = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
