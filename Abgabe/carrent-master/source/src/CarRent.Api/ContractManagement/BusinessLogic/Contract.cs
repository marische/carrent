using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.ContractManagement.BusinessLogic
{
    public class Contract
    {
        private readonly int contract_id;
        private readonly string state;
        private readonly int customer_id;
        private readonly int carclass_id;
        private readonly string startdate;
        private readonly string enddate;
        private readonly string contractdate;
        private readonly decimal totalamount;

        public Contract(int contract_id, string state, int customer_id, int carclass_id, string startdate, string enddate, string contractdate, decimal totalamount)
        {
            this.contract_id = contract_id;
            this.state = state;
            this.customer_id = customer_id;
            this.carclass_id = carclass_id;
            this.startdate = startdate;
            this.enddate = enddate;
            this.contractdate = contractdate;
            this.totalamount = totalamount;
        }

        public int Contract_id => contract_id;
        public string State => state;
        public int Customer_id => customer_id;
        public int Carclass_id => carclass_id;
        public string Startdate => startdate;
        public string Enddate => enddate;
        public string Contractdate => contractdate;
        public decimal Totalamount => totalamount;
    }
}
