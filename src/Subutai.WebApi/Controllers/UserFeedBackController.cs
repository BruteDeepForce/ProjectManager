using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Subutai.Domain.Ports;
using Subutai.Domain.Ports.DTO;

namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserFeedBackController : ControllerBase
    {
        private readonly IUserTaskFeedbackRepository _userTaskFeedbackRepository;

        public UserFeedBackController(IUserTaskFeedbackRepository userTaskFeedbackRepository)
        {
            _userTaskFeedbackRepository = userTaskFeedbackRepository;
        }
        [HttpPost("complete")]
        public async Task<IActionResult> CompleteTask(UserTaskDTO userTaskDTO)
        {
            var response = await _userTaskFeedbackRepository.CompleteTask(userTaskDTO);
            return Ok(response);
        }
    }
}