using iCheap.Models;
using iCheap.Repositories;
using System.Web.Http;

namespace iCheap.WebApp.API
{
    [RoutePrefix("v1/categories")]
    public class CategoryInfoController : BaseAPIController
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryInfoController(ICategoryRepository _CategoryRepository)
        {
            CategoryRepository = _CategoryRepository;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            return Ok(BaseHelpers.CreateResponse(CategoryRepository.GetAllCategories()));
        }

        [Route("{categoryId}")]
        [HttpGet]
        public IHttpActionResult GetCategoryById(int categoryId)
        {
            return Ok(BaseHelpers.CreateResponse(CategoryRepository.GetCategoryById(categoryId)));
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddCategory([FromBody]Categories category)
        {
            var message = CategoryRepository.InsertCategory((User as CustomPrincipal).UserId, category);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Add new category [{ category.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("edit")]
        [HttpPost]
        public IHttpActionResult EditCategory([FromBody]Categories category)
        {
            var message = CategoryRepository.UpdateCategory((User as CustomPrincipal).UserId, category);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Update category [{ category.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("remove")]
        [HttpPost]
        public IHttpActionResult RemoveCategory([FromBody]Categories category)
        {
            var message = CategoryRepository.DeleteCategory((User as CustomPrincipal).UserId, category.CategoryID + string.Empty);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Delete category [{ category.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }
    }
}
