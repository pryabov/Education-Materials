using Mastery.Example.BLL.Common.Models.Customer;
using System.Collections.Generic;

namespace Mastery.Example.BLL.Common.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerViewModel> GetCustomers();

        CustomerViewModel CreateCustomers(CustomerRequestModel customer);
    }
}