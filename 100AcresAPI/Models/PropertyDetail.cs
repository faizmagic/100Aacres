using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _100AcresAPI.Models
{
    public class ContactDetails
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class Slide
    {
        public string Image { get; set; }
    }

    public class OtherFeatures
    {
        public string Ownership { get; set; }
        public string Furnishing { get; set; }
    }

    public class PropertyDetail
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public int Price { get; set; }
        public DateTime PostedOn { get; set; }
        public string ID { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string TransactionType { get; set; }
        public float PropertyAge { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int BuildUpArea { get; set; }
        public float PlotArea { get; set; }
        public List<string> PropertyDescription { get; set; }
        public List<string> PropertyFeatures { get; set; }
        public List<string> Facilities { get; set; }
        public OtherFeatures OtherFeatures { get; set; }
        public List<string> Landmarks { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public List<Slide> Slides { get; set; }
        public List<string> Thumbnails { get; set; }
    }
}