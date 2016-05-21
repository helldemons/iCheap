using iCheap.Repositories;
using System.Web.Mvc;
using System.Linq;
using iCheap.Models;

namespace iCheap.WebApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ICategoryRepository CategoryRepository;
        private readonly IProductRepository ProductRepository;

        public HomeController(
            ICategoryRepository _categoryRepository,
            IProductRepository _productRepository)
        {
            CategoryRepository = _categoryRepository;
        }

        public ActionResult _CategoryMenuHome()
        {
            var categories = CategoryRepository.GetAllCategories();

            ViewBag.CategoryMenu = BaseHelpers.GetParentChildCategoryList(categories);
            return PartialView();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}