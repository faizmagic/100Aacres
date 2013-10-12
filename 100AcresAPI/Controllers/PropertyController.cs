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
            
            using (StreamReader r = new StreamReader(@"C:\Users\FAIZ\Documents\GitHub\LibertyCoder\100Aacres\100AcresAPI\Listings\listings.json"))
            {
                string json = r.ReadToEnd();
                listings = JsonConvert.DeserializeObject<List<Listings>>(json);
            }
            HttpContext context = HttpContext.Current;
            context.Response.AppendHeader("Access-Control-Allow-Origin", "http://localhost:3815");
            //HttpResponseMessage response = Request.CreateResponse<IEnumerable<Listings>>(HttpStatusCode.OK, listings);
            //response.Headers.Add("Access-Control-Allow-Origin", "*");
            return listings;
        }
    }
}
