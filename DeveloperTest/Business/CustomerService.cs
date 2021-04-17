using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Interfaces;
using DeveloperTest.Database.Models;
using DeveloperTest.Helpers;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _repository;

        public CustomerService(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<APIResponse> GetCustomers()
        {
            var result = await _repository.GetCustomers();
            return new APIResponse(Errors.Success, (int)HttpStatusCode.OK) { Result = result };
        }

        public async Task<APIResponse> GetCustomer(int customerId)
        {
            if (customerId == 0)
                return new APIResponse(Errors.Id_Invalid);
            var result =await _repository.GetCustomer(customerId);
            return new APIResponse(Errors.Success, (int)HttpStatusCode.OK) { Result = result }; 
        }

        public async Task<APIResponse> CreateCustomer(BaseCustomerModel model)
        {
            if (string.IsNullOrEmpty(model.Name)||string.IsNullOrEmpty(model.Type))
                return new APIResponse(Errors.CustomerInfo_Invalid);
            if (model.Name.Length<5)
                return new APIResponse(Errors.CustomerName_Invalid);

            var entity = new Customer() { Name = model.Name, Type = model.Type };
            var result = await _repository.CreateCustomer(entity);
            
            return new APIResponse(Errors.Success, (int)HttpStatusCode.OK) { Result = result };          
        }
          
    }
}
