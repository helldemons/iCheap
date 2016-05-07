using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iCheap.WebApp
{
    public class CustomAuthorization : AuthorizeAttribute
    {
        string[] _roles;
        public CustomAuthorization(params string[] roles)
        {
            _roles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUser = httpContext.User as CustomPrincipal;
            try
            {
                foreach (var role in _roles)
                {
                    if (string.Equals(currentUser.Role.ToString(), role, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Home",
                                action = "UnAuthorize"
                            })
                        );
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}