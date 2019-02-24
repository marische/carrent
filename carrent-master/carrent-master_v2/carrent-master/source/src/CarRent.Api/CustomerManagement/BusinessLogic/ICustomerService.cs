using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Api.CustomerManagement.BusinessLogic
{
    public interface ICustomerService
    {
        IReadOnlyList<Customer> GetAll();
        void PostCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
