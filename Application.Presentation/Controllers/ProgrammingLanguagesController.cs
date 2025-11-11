using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Presentation.Controllers
{
    [Route("api/programmingLanguages")]
    [ApiController]
    public class ProgrammingLanguagesController : ControllerBase    
    {
        private readonly IServiceManager _service;

        public ProgrammingLanguagesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProgrammingLanguages()
        {
            try {
                var programmingLanguages = await _service.ProgrammingLanguageService.GetAllLanguages(trackChanges: false);
                return Ok(programmingLanguages);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
