using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using _100AcresAPI.Models;
using System.Net;
using System.Web.Security;

namespace _100AcresAPI.Controllers
{
    public class AuthenticateController : ApiController
    {
        public HttpResponseMessage PostAuthenticateUser(Credential credential)
        {
            FormsAuthentication.SetAuthCookie(credential.UserName, true);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            //response.Headers.
            return response;
        }
    }
}
