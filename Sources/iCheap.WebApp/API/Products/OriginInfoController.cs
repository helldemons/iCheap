using iCheap.Models;
using iCheap.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace iCheap.WebApp.API
{
    [RoutePrefix("v1/origins")]
    public class OriginInfoController : BaseAPIController
    {
        private readonly IOriginRepository OriginRepository;

        public OriginInfoController(IOriginRepository _originRepository)
        {
            OriginRepository = _originRepository;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllOrigins()
        {
            return Ok(BaseHelpers.CreateResponse(OriginRepository.GetAllOrigins()));
        }

        [Route("{originId}")]
        [HttpGet]
        public IHttpActionResult GetOriginById(int originId)
        {
            return Ok(BaseHelpers.CreateResponse(OriginRepository.GetOriginById(originId)));
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult AddOrigin([FromBody]Origins origin)
        {
            var message = OriginRepository.InsertOrigin((User as CustomPrincipal).UserId, origin);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Add new origin [{ origin.VNName }] successfully!";
            }
            
            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("edit")]
        [HttpPost]
        public IHttpActionResult EditOrigin([FromBody]Origins origin)
        {
            var message = OriginRepository.UpdateOrigin((User as CustomPrincipal).UserId, origin);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Update origin [{ origin.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }

        [Route("remove")]
        [HttpPost]
        public IHttpActionResult RemoveOrigin([FromBody]Origins origin)
        {
            var message = OriginRepository.DeleteOrigin((User as CustomPrincipal).UserId, origin.OriginID + string.Empty);
            bool status = false;
            if (string.IsNullOrEmpty(message))
            {
                status = true;
                message = $"Delete origin [{ origin.VNName }] successfully!";
            }

            return Ok(new ResultItem { Status = status, Message = message });
        }
    }
}
