using DeveloperTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public class EngineerService : IEngineerService
    {
        public async Task<APIResponse> GetEngineers()
        {
            string[] Engineers = { "Ashley", "Dave", "Kalina" };
            return new APIResponse(Errors.Success, (int)HttpStatusCode.OK) { Result = Engineers };
        }
    }
}
