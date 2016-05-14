using System.Web.Mvc;

namespace iCheap.WebApp.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
    }
}