using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using _100AcresAPI.Models;
using System.Net.Http;
using System.Net;
using System.Web.Security;

namespace _100AcresAPI.Controllers
{
    public class RegisterController : ApiController
    {
        public HttpResponseMessage PostRegisterUser(User user)
        {
            //Membership.ValidateUser(
            var response = Request.CreateResponse(HttpStatusCode.OK, user);
            return response;
        }
    }
}
