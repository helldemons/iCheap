using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace iCheap.WebApp
{
    public class CustomAuthorizationWebApi : AuthorizeAttribute
    {
        string[] _roles;
        public CustomAuthorizationWebApi(params string[] roles)
        {
            _roles = roles;
        }

        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var currentUser = HttpContext.Current.User as CustomPrincipal;
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

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
        }

    }
}