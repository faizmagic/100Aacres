using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using _100AcresAPI.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Web.Hosting;

namespace _100AcresAPI.Controllers
{
    public class PropertyController : ApiController
    {
        //[HttpHeaderAttribute("Access-Control-Allow-Origin", "*")]
        public IEnumerable<Listings> GetListings()
        {
            return LoadListingsFromJson();
        }

        private IEnumerable<Listings> LoadListingsFromJson()
        {
            IEnumerable<Listings> listings = null;
            string PATH = HostingEnvironment.MapPath(@"~\Listings");
            string fileName = Path.Combine(PATH, "listings.json");

            using(StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                listings = JsonConvert.DeserializeObject<List<Listings>>(json);
            }
            HttpContext context = HttpContext.Current;
            context.Response.AppendHeader("Access-Control-Allow-Origin", "http://localhost");
            //HttpResponseMessage response = Request.CreateResponse<IEnumerable<Listings>>(HttpStatusCode.OK, listings);
            //response.Headers.Add("Access-Control-Allow-Origin", "*");
            return listings;
        }

        /// <summary>
        /// Post Property Ad - save general information
        /// </summary>
        /// <param name="generalInfo"></param>
        /// <returns></returns>
        public HttpResponseMessage PostSaveGenInfo(GeneralInformation generalInfo)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Post Property Ad - save property details
        /// </summary>
        /// <param name="propFeature"></param>
        /// <returns></returns>
        public HttpResponseMessage PostSavePropertyFeatures(PropertyFeature propFeature)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

    }
}
