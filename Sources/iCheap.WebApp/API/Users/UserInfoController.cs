using iCheap.Models;
using iCheap.Repositories;
using System.Web.Http;

namespace iCheap.WebApp.API
{
    [RoutePrefix("v1/users")]
    public class UserInfoController : BaseAPIController
    {
        private readonly IUserRepository UserRepository;

        public UserInfoController(IUserRepository _userRepository)
        {
            UserRepository = _userRepository;
        }

        [Route("login/{username}/{password}")]
        [HttpGet]
        public IHttpActionResult UserLogin(
            string username, 
            string password)
        {
            return Ok(BaseHelpers.CreateResponse(UserRepository.UserLogin(username, password)));
        }
    }
}
