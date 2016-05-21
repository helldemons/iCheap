using System.Web.Mvc;

namespace iCheap.WebApp.Controllers
{
    public class BlogCategoryController : BaseController
    {
        // GET: BlogCategory
        public ActionResult Index()
        {
            return View();
        }
    }
}