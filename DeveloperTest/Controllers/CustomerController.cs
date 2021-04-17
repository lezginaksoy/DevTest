using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Helpers;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseAPIController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customerList = await _customerService.GetCustomers();
            if (customerList.Code != (int)Errors.Success)
                return Error(customerList.ErrorEnum);

            return Ok(customerList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.GetCustomer(id);
            if (customer.Code != (int)Errors.Success)
                return Error(customer.ErrorEnum);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BaseCustomerModel model)
        {
            var customer = await _customerService.CreateCustomer(model);
            if (customer.Code != (int)Errors.Success)
                return Error(customer.ErrorEnum);

            return Ok(customer);
        }

    }
}
