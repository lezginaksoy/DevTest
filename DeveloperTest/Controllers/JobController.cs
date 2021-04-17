using System;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using System.Threading.Tasks;
using DeveloperTest.Helpers;

namespace DeveloperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : BaseAPIController
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            this._jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobList = await _jobService.GetJobs();
            if (jobList.Code != (int)Errors.Success)
                return Error(jobList.ErrorEnum);

            return Ok(jobList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var job = await _jobService.GetJob(id);
            if (job.Code != (int)Errors.Success)
                return Error(job.ErrorEnum);

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BaseJobModel model)
        {
            var newJob = await _jobService.CreateJob(model);
            if (newJob.Code != (int)Errors.Success)
                return Error(newJob.ErrorEnum);

            return Ok(newJob);
        }
    }
}