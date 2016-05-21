using iCheap.Models;
using iCheap.Repositories;
using System.Web.Mvc;
using System.Linq;
using System;

namespace iCheap.WebApp.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository CategoryRepository;
        private readonly IProductRepository ProductCategory;

        public CategoryController(
            ICategoryRepository _categoryRepository,
            IProductRepository _productRepository)
        {
            CategoryRepository = _categoryRepository;
            ProductCategory = _productRepository;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryDetail(int id, string url)
        {
            var category = CategoryRepository.GetCategoryById(id);
            if (!url.ToLower().Equals(category.VNRewriteUrl.ToLower()))
                return RedirectToAction("NotFound", "Error");

            var categories = BaseHelpers.GetParentChildCategoryList(CategoryRepository.GetAllCategories());
            var products = ProductCategory.GetProductByProductFilter(new Products
            {
                CategoryID = id
            });

            ViewBag.Products = products;
            ViewBag.Categories = categories;
            ViewData["category"] = category;
            return View(category);
        }
    }
}