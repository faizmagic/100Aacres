using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using _100AcresAPI.Models;
using System.Web.Hosting;
using System.IO;
using Newtonsoft.Json;

namespace _100AcresAPI.Controllers
{
    public class PropertyDetailController : ApiController
    {
        public PropertyDetail GetPropertyDetail(int ID)
        {
            PropertyDetail response = null;

            string PATH = HostingEnvironment.MapPath(@"~\Listings");
            string fileName = Path.Combine(PATH, ID + ".json");

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                response = JsonConvert.DeserializeObject<PropertyDetail>(json);
            }

            return response;
        }

    }
}
