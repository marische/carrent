using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Api.CarManagement.Domain;
using CarRent.Api.CarManagement.Interface;
using CarRent.Api.CarManagement.Persistence;
using CarRent.Api.CustomerManagement.BusinessLogic;
using CarRent.Api.CustomerManagement.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Api.CustomerManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            IReadOnlyList<Customer> customers = customerService.GetAll();
            return customers.Select(c => new CustomerDto
            {
                Customer_id = c.Customer_id,
                Firstname = c.Firstname,
                Surname = c.Surname,
                Street = c.Street,
                Zip = c.Zip,
                Town = c.Town,
                Country = c.Country,
                Phone = c.Phone,
                Mail = c.Mail,
                Birthdate = c.Birthdate
        });
        }

        /*
         * 
         * POST: api/Customer
         * */
        [HttpPost]
        public void Post([FromBody] IReadOnlyList<CustomerDto> dto)
        {
            for (var i = 0; i < dto.Count; i++)
            {
                Customer customer = new Customer(
                dto[i].Customer_id,
                dto[i].Firstname,
                dto[i].Surname,
                dto[i].Street,
                dto[i].Zip,
                dto[i].Town,
                dto[i].Country,
                dto[i].Phone,
                dto[i].Mail,
                dto[i].Birthdate
                );

                customerService.PostCustomer(customer);
            }
        }



        /*
         * PUT: api/Customer/id
         * */
        [HttpPut("{id}")]
        public void Put([FromBody] IReadOnlyList<CustomerDto> dto)
        {
            for (var i = 0; i < dto.Count; i++)
            {

                Customer customer = new Customer(
                dto[i].Customer_id,
                dto[i].Firstname,
                dto[i].Surname,
                dto[i].Street,
                dto[i].Zip,
                dto[i].Town,
                dto[i].Country,
                dto[i].Phone,
                dto[i].Mail,
                dto[i].Birthdate
                );

                
                customerService.UpdateCustomer(customer);

            }
        }

        // DELETE: api/Customer/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerService.DeleteCustomer(id);
        }
    }
}
