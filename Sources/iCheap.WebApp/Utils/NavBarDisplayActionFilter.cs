using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace iCheap.WebApp
{
    public class NavBarDisplayActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var customPrincipal = filterContext.HttpContext.User as CustomPrincipal;
            if (customPrincipal != null && customPrincipal.Identity.IsAuthenticated)
            {
                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                var tmp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "navbar.json");

                var navBarItems = new List<NavItem>();
                navBarItems = BaseHelpers.GetNavItemList(urlHelper, tmp);

                filterContext.Controller.ViewBag.NavBarItems = navBarItems;
                filterContext.Controller.ViewBag.DropDownItems = navBarItems;
                filterContext.Controller.ViewBag.UserId = customPrincipal.UserId;
                filterContext.Controller.ViewBag.Role = customPrincipal.Role;
                filterContext.Controller.ViewBag.Username = customPrincipal.Username;
            }
            base.OnActionExecuted(filterContext);
        }
    }
}