using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperTest.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class EngineerController : ControllerBase
    {
  
        private readonly IEngineerService  _engineerService;
        public EngineerController(IEngineerService engineerService)
        {
            _engineerService = engineerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var engineer= await _engineerService.GetEngineers();
            return Ok(engineer);
        }
    }
}
