using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Database.Interfaces
{
    public interface IRepository
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomer(int customerId);

        Task<Customer> CreateCustomer(Customer model);
        Task<List<Job>> GetJobs();

        Task<Job> GetJob(int jobId);

        Task<Job> CreateJob(Job model);
    }
}
