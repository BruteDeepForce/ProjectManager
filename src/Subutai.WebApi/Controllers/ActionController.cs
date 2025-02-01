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
using Microsoft.EntityFrameworkCore;
using Tensorflow.Gradients;
using Subutai.Domain.Ports.DTO;


namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionController : ControllerBase
    {
        private readonly IProjectEntityRepository _projectEntityRepository;
        private readonly ITaskEntityRepository _taskEntityRepository;

        private readonly SubutaiContext _subutaiContext;
        public ActionController(IProjectEntityRepository projectEntityRepository, ITaskEntityRepository taskEntityRepository, SubutaiContext subutaiContext)
        {
            _projectEntityRepository = projectEntityRepository;
            _taskEntityRepository = taskEntityRepository;
            _subutaiContext = subutaiContext;
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
        [HttpPost("addtask")]
        public async Task<IActionResult> AddTask(UserTaskDTO userTaskDto)
        {
            if(ModelState.IsValid)
            {
                var response = await _taskEntityRepository.AddTaskAsync(userTaskDto);
                if(response is not null) return Ok(response);
                return BadRequest(response);
            }
            return BadRequest();
        }
        [HttpGet("gettask")]
        public async Task<IActionResult> GetTask(int id)
        {
                var response = await _taskEntityRepository.GetTaskAsync(id);

                return Ok(response);
   
        }
    }
}