using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _100AcresAPI.Models
{
    public class GeneralInformation
    {
        public string TransactionType { get; set; }
        public string PropertyCtaegory { get; set; }
        public string PropertyType { get; set; }
        public string Title { get; set; }
        public float PropertyAge { get; set; }
        public int NoOfBedrooms { get; set; }
        public int NoOfBathrooms { get; set; }
        public int BuildUpArea { get; set; }
        public int PlotArea { get; set; }
        public string PropertyStatus { get; set; }
        public int LandArea { get; set; }
        public string LandAreaUnit { get; set; }
        public float PropertyPrice { get; set; }
        public bool Gross { get; set; }
        public bool PerUnit { get; set; }
        public string PerUnitUnit { get; set; }
        public bool PriceNegotiable { get; set; }
        public string Description { get; set; }
        public string PropertyDetails { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string ContactName { get; set; } 
        public string ContactAddress { get; set; }
        public int ContactPhone { get; set; }
        public int ContactMobile { get; set; }
    }
}