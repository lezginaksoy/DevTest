using DeveloperTest.Database.Interfaces;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Database
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomer(Customer model)
        {
            var addedCustomer = _context.Customers.Add(model);
            var customerId = await _context.SaveChangesAsync();

            return new Customer
            {
                CustomerId = customerId,
                Name = addedCustomer.Entity.Name,
                Type = addedCustomer.Entity.Type
            };
        }

        public async Task<Job> CreateJob(Job model)
        {
            _context.Jobs.Add(model);
            var jobId = await _context.SaveChangesAsync();
            return await GetJob(jobId);
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Job> GetJob(int jobId)
        {
            return await _context.Jobs.Where(x => x.JobId == jobId)
           .Include(job => job.Customer)
           .Select(x => new Job
           {
               JobId = x.JobId,
               Engineer = x.Engineer,
               When = x.When,
               Customer = x.Customer == null ?
               new Customer { CustomerId = 0, Name = "Unknown", Type = "Unknown" } :
               new Customer { CustomerId = x.Customer.CustomerId, Name = x.Customer.Name, Type = x.Customer.Type }

           }).FirstOrDefaultAsync();
        }

        public async Task<List<Job>> GetJobs()
        {
            return await _context.Jobs.Include(job => job.Customer)
            .Select(x => new Job
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                Customer = x.Customer == null ?
                  new Customer { CustomerId = 0, Name = "Unknown", Type = "Unknown" } :
                  new Customer { CustomerId = x.Customer.CustomerId, Name = x.Customer.Name, Type = x.Customer.Type }

            }).ToListAsync();
        }
    }
}
