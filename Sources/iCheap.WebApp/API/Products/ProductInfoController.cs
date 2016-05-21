using iCheap.Models;
using iCheap.Repositories;
using System.Web.Http;

namespace iCheap.WebApp.API
{
    [RoutePrefix("v1/products")]
    public class ProductInfoController : BaseAPIController
    {
        private readonly IProductRepository ProductRepository;

        public ProductInfoController(IProductRepository _productRepository)
        {
            ProductRepository = _productRepository;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            return Ok(BaseHelpers.CreateResponse(ProductRepository.GetAllProducts()));
        }

        [Route("{productId}")]
        [HttpGet]
        public IHttpActionResult GetProductById(int productId)
        {
            return Ok(BaseHelpers.CreateResponse(ProductRepository.GetProductById(productId)));
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddProduct([FromBody]Products Product)
        {
            var message = ProductRepository.InsertProduct((User as CustomPrincipal).UserId, Product);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Add new product [{ Product.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("edit")]
        [HttpPost]
        public IHttpActionResult EditProduct([FromBody]Products Product)
        {
            var message = ProductRepository.UpdateProduct((User as CustomPrincipal).UserId, Product);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Update product [{ Product.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("remove")]
        [HttpPost]
        public IHttpActionResult RemoveProduct([FromBody]Products Product)
        {
            var message = ProductRepository.DeleteProduct((User as CustomPrincipal).UserId, Product.ProductID + string.Empty);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Delete product [{ Product.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }
    }
}
