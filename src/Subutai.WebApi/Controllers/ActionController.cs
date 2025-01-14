using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;

namespace Subutai.WebApi.Controllers
{
    [Route("[controller]")]
    public class ActionController : Controller
    {
        private readonly ILogger<ActionController> _logger;
        private readonly IProjectEntityRepository _projectEntityRepository;
        

        public ActionController(ILogger<ActionController> logger, IProjectEntityRepository projectEntityRepository)
        {
            _logger = logger;
            _projectEntityRepository = projectEntityRepository;
        }

        [HttpPost("addProject")]
        public async Task<IActionResult> Addproject ([FromBody] ProjectEntity project)
        {
            // await _projectEntityRepository.AddAsync(project);

            return Ok();
        }      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}