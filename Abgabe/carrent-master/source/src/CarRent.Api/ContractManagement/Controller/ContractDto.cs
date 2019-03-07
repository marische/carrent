using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.ContractManagement.Controller
{
    public class ContractDto
    {
        public int Contract_id { get; set; }
        public string State { get; set; }
        public int Customer_id { get; set; }
        public int Carclass_id { get; set; }
        public string Startdate { get; set; }
        public string Enddate { get; set; }
        public string Contractdate { get; set; }
        public decimal Totalamount { get; set; }
    }
}
