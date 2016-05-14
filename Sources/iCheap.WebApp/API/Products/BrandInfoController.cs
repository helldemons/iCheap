using iCheap.Models;
using iCheap.Repositories;
using System.Web.Http;

namespace iCheap.WebApp.API
{
    [RoutePrefix("v1/brands")]
    public class BrandInfoController : BaseAPIController
    {
        private readonly IBrandRepository BrandRepository;

        public BrandInfoController(IBrandRepository _BrandRepository)
        {
            BrandRepository = _BrandRepository;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllBrands()
        {
            return Ok(BaseHelpers.CreateResponse(BrandRepository.GetAllBrands()));
        }

        [Route("{brandId}")]
        [HttpGet]
        public IHttpActionResult GetBrandById(int brandId)
        {
            return Ok(BaseHelpers.CreateResponse(BrandRepository.GetBrandById(brandId)));
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddBrand([FromBody]Brands brand)
        {
            var message = BrandRepository.InsertBrand((User as CustomPrincipal).UserId, brand);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Add new brand [{ brand.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("edit")]
        [HttpPost]
        public IHttpActionResult EditBrand([FromBody]Brands brand)
        {
            var message = BrandRepository.UpdateBrand((User as CustomPrincipal).UserId, brand);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Update brand [{ brand.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("remove")]
        [HttpPost]
        public IHttpActionResult RemoveBrand([FromBody]Brands brand)
        {
            var message = BrandRepository.DeleteBrand((User as CustomPrincipal).UserId, brand.BrandID + string.Empty);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Delete brand [{ brand.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }
    }
}
