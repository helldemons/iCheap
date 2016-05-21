using iCheap.Models;
using iCheap.Repositories;
using System.Web.Mvc;

namespace iCheap.WebApp.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ICategoryRepository CategoryRepository;
        private readonly IProductRepository ProductRepository;

        public ProductController(
            ICategoryRepository _categoryRepository,
            IProductRepository _productRepository)
        {
            CategoryRepository = _categoryRepository;
            ProductRepository = _productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductDetail(int id, string url)
        {
            var product = ProductRepository.GetProductById(id);
            if (!url.ToLower().Equals(product.VNRewriteUrl.ToLower()))
                return RedirectToAction("NotFound", "Error");

            var category = CategoryRepository.GetCategoryById(product.Category.CategoryID ?? 0);
            var relatedProduces = ProductRepository.GetProductByProductFilter(new Products
            {
                CategoryID = product.Category.Parent != null ? product.Category.Parent.CategoryID : product.Category.CategoryID
            });
            ProductRepository.UpdateViewCount(id);

            product.Category = category;
            ViewBag.RelatedProducts = relatedProduces;
            return View(product);
        }
    }
}