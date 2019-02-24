using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CustomerManagement.BusinessLogic
{
    interface ICustomerRepository
    {
        IReadOnlyList<Customer> GetAll();
        void PostCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
