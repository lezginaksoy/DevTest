using System;
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
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly IRepository _repository;

        public JobService(IRepository repository)
        {
            this._repository = repository;
        }
        public async Task<APIResponse> GetJobs()
        {
            var result = await _repository.GetJobs();
            return new APIResponse(Errors.Success, (int)HttpStatusCode.OK) { Result = result };
        }

        public async Task<APIResponse> GetJob(int jobId)
        {
            if (jobId == 0)
                return new APIResponse(Errors.Id_Invalid);
            var result = await _repository.GetJob(jobId);
            return new APIResponse(Errors.Success, (int)HttpStatusCode.OK) { Result = result };
        }

        public async Task<APIResponse> CreateJob(BaseJobModel model)
        {
            if (string.IsNullOrEmpty(model.Engineer))
                return new APIResponse(Errors.Job_EngineerField_Invalid);

            if (model.Customer == null)
                return new APIResponse(Errors.Job_CustomerField_Invalid);

            if (model.Customer.CustomerId == 0)
                return new APIResponse(Errors.Id_Invalid);

            if (model.When.Date < DateTime.Now.Date)
                return new APIResponse(Errors.Date_Invalid);

            var entity = new Job()
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.Customer.CustomerId
            };
            var result = await _repository.CreateJob(entity);

            return new APIResponse(Errors.Success, (int)HttpStatusCode.OK) { Result = result };
        }

        public async Task<APIResponse> GetEngineers()
        {
            string[] Engineers = { "Ashley", "Dave", "Kalina" };
            return new APIResponse(Errors.Success, (int)HttpStatusCode.OK) { Result = Engineers };

        }
    }
}
