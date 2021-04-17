using DeveloperTest.Helpers;
using DeveloperTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<APIResponse> GetCustomers();

        Task<APIResponse> GetCustomer(int customerId);

        Task<APIResponse> CreateCustomer(BaseCustomerModel model);       
    }
}
