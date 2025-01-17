using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;
using Subutai.Repository.SqlRepository.Contexts;
using Subutai.Repository.SqlRepository.Repositories;

namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionController : ControllerBase
    {
        public readonly IProjectEntityRepository _projectEntityRepository;
        public ActionController(IProjectEntityRepository projectEntityRepository)
        {
            _projectEntityRepository = projectEntityRepository;

        }
        [HttpPost("addProject")]
        public async Task<IActionResult> Addproject ([FromBody] ProjectEntity project)
        {
            await _projectEntityRepository.AddAsync(project);

            return Ok();
        }      
    }
}