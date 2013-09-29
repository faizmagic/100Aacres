using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _100AcresAPI.Models
{
    public class User
    {
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PhoneNo { get; set; }
    }
}