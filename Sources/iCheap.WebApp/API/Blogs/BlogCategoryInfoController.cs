using iCheap.Models;
using iCheap.Repositories;
using System.Web.Http;

namespace iCheap.WebApp.API
{
    [RoutePrefix("v1/blogCategories")]
    public class BlogCategoryInfoController : BaseAPIController
    {
        private readonly IBlogCategoryRepository BlogCategoryRepository;

        public BlogCategoryInfoController(IBlogCategoryRepository _blogCategoryRepository)
        {
            BlogCategoryRepository = _blogCategoryRepository;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllBlogCategories()
        {
            return Ok(BaseHelpers.CreateResponse(BlogCategoryRepository.GetAllBlogCategories()));
        }

        [Route("{blogCategoryId}")]
        [HttpGet]
        public IHttpActionResult GetBlogCategoryById(int blogCategoryId)
        {
            return Ok(BaseHelpers.CreateResponse(BlogCategoryRepository.GetBlogCategoryById(blogCategoryId)));
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddBlogCategory([FromBody]BlogCategories blogCategory)
        {
            var message = BlogCategoryRepository.InsertBlogCategory((User as CustomPrincipal).UserId, blogCategory);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Add new blog category [{ blogCategory.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("edit")]
        [HttpPost]
        public IHttpActionResult EditBlogCategory([FromBody]BlogCategories blogCategory)
        {
            var message = BlogCategoryRepository.UpdateBlogCategory((User as CustomPrincipal).UserId, blogCategory);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Update blog category [{ blogCategory.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("remove")]
        [HttpPost]
        public IHttpActionResult RemoveBlogCategory([FromBody]BlogCategories blogCategory)
        {
            var message = BlogCategoryRepository.DeleteBlogCategory((User as CustomPrincipal).UserId, blogCategory.BlogCategoryID + string.Empty);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Delete blog category [{ blogCategory.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }
    }
}
