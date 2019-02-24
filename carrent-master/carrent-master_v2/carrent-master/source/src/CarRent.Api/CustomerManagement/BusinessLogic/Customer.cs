using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CustomerManagement.BusinessLogic
{
    public class Customer
    {
        private readonly int customer_id;
        private readonly string firstname;
        private readonly string surname;
        private readonly string street;
        private readonly string zip;
        private readonly string town;
        private readonly string country;
        private readonly string phone;
        private readonly string mail;
        private readonly string birthdate;
        
        public Customer(int customer_id, string firstname, string surname, string street, string zip, string town, string country, string phone, string mail, string birthdate)
        {
            this.customer_id = customer_id;
            this.firstname = firstname;
            this.surname = surname;
            this.street = street;
            this.zip = zip;
            this.town = town;
            this.country = country;
            this.phone = phone;
            this.mail = mail;
            this.birthdate = birthdate;
        }

        public int Customer_id => customer_id;
        public string Firstname => firstname;
        public string Surname => surname;
        public string Street => street;
        public string Zip => zip;
        public string Town => town;
        public string Country => country;
        public string Phone => phone;
        public string Mail => mail;
        public string Birthdate => birthdate;
    }
}
