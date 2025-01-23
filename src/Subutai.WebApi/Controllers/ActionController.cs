using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;
using Subutai.Repository.SqlRepository.Contexts;
using Subutai.Repository.SqlRepository.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

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
        [HttpPost("updateProject")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectEntity project)
        {
            await _projectEntityRepository.UpdateAsync(project);

            return Ok();
        }    
        [HttpPost("deleteproject/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectEntityRepository.DeleteAsync(id);

            return Ok();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet("getProjects")]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectEntityRepository.GetAsync();

            return Ok(projects);
        }
    }
}