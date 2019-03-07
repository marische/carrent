using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Api.ContractManagement.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Api.ContractManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService contractService;

        public ContractController(IContractService contractService)
        {
            this.contractService = contractService;
        }

        // GET: api/Contract
        [HttpGet]
        public IEnumerable<ContractDto> Get()
        {
            IReadOnlyList<Contract> contracts = contractService.GetAll();
            return contracts.Select(c => new ContractDto
            {
                Contract_id = c.Contract_id,
                State = c.State,
                Customer_id = c.Customer_id,
                Carclass_id = c.Carclass_id,
                Startdate = c.Startdate,
                Enddate = c.Enddate,
                Contractdate = c.Contractdate,
                Totalamount = c.Totalamount 
            });
        }

       
         /*
         *  POST: api/Car
         * */
        [HttpPost]
        public void Post([FromBody] IReadOnlyList<ContractDto> dto)
        {
            for (var i = 0; i < dto.Count; i++)
            {
                Contract contract = new Contract(
                dto[i].Contract_id,
                dto[i].State,
                dto[i].Customer_id,
                dto[i].Carclass_id,
                dto[i].Startdate,
                dto[i].Enddate,
                dto[i].Contractdate,
                dto[i].Totalamount
                );

                contractService.WriteContract(contract);
            }
        }



        /*
         * PUT: api/Contract/id
         * */
        [HttpPut]
        public void Put([FromBody] IReadOnlyList<ContractDto> dto)
        {
            for (var i = 0; i < dto.Count; i++)
            {
                Contract contract = new Contract(
                dto[i].Contract_id,
                dto[i].State,
                dto[i].Customer_id,
                dto[i].Carclass_id,
                dto[i].Startdate,
                dto[i].Enddate,
                dto[i].Contractdate,
                dto[i].Totalamount);

                contractService.UpdateContract(contract);

            }
        }

        // DELETE: api/Contract/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            contractService.DeleteContract(id);
        }
    }
}