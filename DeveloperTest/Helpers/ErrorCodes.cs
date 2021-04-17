using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Helpers
{
    public enum Errors
    {
        [Description("Success")]
        Success = 0,

        [Description("Invalid Id")]
        Id_Invalid = 612,

        [Description("Customer Name or Type is invalid")]
        CustomerInfo_Invalid = 613,

        [Description("Customer Name must have a minimum length of 5 characters")]
        CustomerName_Invalid = 614,
       
        [Description("Engineer field must be filled while creat a job")]
        Job_EngineerField_Invalid = 615,

        [Description("Customer object must be filled while creat a job")]
        Job_CustomerField_Invalid = 616,

        [Description("Date can't be in the past")]
        Date_Invalid = 617,


        [Description("Unknown Error")]
        Unknown_error = 7000,

        [Description("Couldn't execute action with the database.")]
        Database_execution_error = 7001
    }

    public static class EnumerationExtension
    {
        static ConcurrentDictionary<Enum, string> descriptionCache = new ConcurrentDictionary<Enum, string>();
        public static string Description(this Enum value)
        {
            if (descriptionCache.ContainsKey(value))
                return descriptionCache[value];

            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);

            // Description is in a hidden Attribute class called DisplayAttribute
            // Not to be confused with DisplayNameAttribute
            dynamic displayAttribute = null;

            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0);
            }

            // return description
            var result = displayAttribute?.Description ?? null;
            if (result != null)
                descriptionCache[value] = result;

            return result;
        }
    }


    [ApiController]
    [Route("[controller]")]
    public class BaseAPIController : ControllerBase
    {

        protected ObjectResult Error(Errors error, int statusCode = 400)
        {      
            var r = new ErrorResult()
            {
                Code = (int)error,
                ErrorEnum = error,
                CodeString = error.ToString(),
                Message = error.Description()
            };

            return StatusCode(statusCode, r);
        }
  
    }

}
