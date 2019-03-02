using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CustomerManagement.BusinessLogic
{
    
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IReadOnlyList<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public void PostCustomer(Customer customer)
        {
            customerRepository.PostCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            customerRepository.PostCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            customerRepository.DeleteCustomer(id);
        }
    }
}
