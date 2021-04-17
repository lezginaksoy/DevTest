using DeveloperTest.Database.Models;
using DeveloperTest.Helpers;
using DeveloperTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface IJobService
    {
        Task<APIResponse> GetJobs();

        Task<APIResponse> GetJob(int jobId);

        Task<APIResponse> CreateJob(BaseJobModel model);
    }
}
