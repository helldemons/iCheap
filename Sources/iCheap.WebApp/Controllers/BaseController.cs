using System.Web.Mvc;

namespace iCheap.WebApp.Controllers
{
    [Authorize]
    [NavBarDisplayActionFilter]
    public class BaseController : Controller
    {
    }
}