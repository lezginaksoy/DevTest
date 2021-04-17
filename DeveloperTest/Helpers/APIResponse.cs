using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Helpers
{

    public class BaseAPIResponse
    {
        public int Code { get; set; } = 0;
        public Errors ErrorEnum { get; set; } = Errors.Success;
        public string CodeString { get; set; } = Errors.Success.ToString();
        public string Message { get; set; } = "Success";

    }

    public class APIResponse: BaseAPIResponse
    {
        public Object Result { get; set; }
        public int StatusCode { get; set; } = 200;

        public APIResponse() : base()
        {
        }

        public APIResponse(Errors code, int statusCode = 400)
        {
            ErrorEnum = code;
            Code = (int)code;
            Message = code.Description();
            StatusCode = statusCode;
        }
    }

    public class ErrorResult : BaseAPIResponse
    {

    }

}
