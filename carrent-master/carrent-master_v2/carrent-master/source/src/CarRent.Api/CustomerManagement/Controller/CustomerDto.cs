using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CustomerManagement.Interface
{
    public class CustomerDto
    {
        public int Customer_id {get; set; } 
        public string Firstname {get; set; } 
        public string Surname {get; set; }
        public string Street {get; set; }
        public string Zip {get; set; } 
        public string Town {get; set; }
        public string Country {get; set; }
        public string Phone {get; set; }
        public string Mail {get; set; }
        public string Birthdate {get; set; }
    }
}
