using DeveloperTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface IEngineerService
    {
        Task<APIResponse> GetEngineers();
    }
}
