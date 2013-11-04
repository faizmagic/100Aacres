using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _100AcresAPI.Models
{
    public class PropertyFeature
    {
        public int PropertyID { get; set; }
        public List<string> Features { get; set; }
        public string Ownership { get; set; }
        public string Landmark { get; set; }
    }
}