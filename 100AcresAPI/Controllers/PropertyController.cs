using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using _100AcresAPI.Models;
using Newtonsoft.Json;
using System.IO;

namespace _100AcresAPI.Controllers
{
    public class PropertyController : ApiController
    {
        
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

            return listings;
        }
    }
}
