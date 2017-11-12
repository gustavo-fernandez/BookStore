using BusinessLogicApi.Business;
using BusinessLogicApi.DTO;
using BusinessLogicImpl.BusinessImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    [RoutePrefix("api/users")]
    public class UserApiController : ApiController
    {
        IUserBusiness userBusiness = new UserBusiness();

        // GET: api/users
        [Route("")]
        [HttpGet]
        public List<CreatedUser> Get()
        {
            List<CreatedUser> users = userBusiness.FindAll();
            return users;
        }

        // POST: api/users
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]NewUser user)
        {
            CreatedUser createdUser = userBusiness.Create(user);
            return Created($"/api/users/{createdUser.Id}", createdUser);
        }
    }
}
