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
            HttpResponseMessage response = null;
            try
            {
                //Save the user data to DB
                //if success set the cookie and authenticate the user
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                //Membership.ValidateUser(
                response = Request.CreateResponse(HttpStatusCode.OK, user);
                response.Headers.Add("Access-Control-Allow-Origin", "*");
            }
            catch (Exception ex)
            {

            }

            return response;

        }
    }
}
