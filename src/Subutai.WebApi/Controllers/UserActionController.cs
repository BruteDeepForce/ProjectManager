using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;

namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserActionController : ControllerBase
    {
        private readonly IUserEntityRepository _userEntityRepository;
        public UserActionController(IUserEntityRepository userEntityRepository)
        {

            _userEntityRepository = userEntityRepository;
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> addUser([FromBody] UserEntity entity)
        {

                var response = await _userEntityRepository.AddAsync(entity);
                if (response != null) return Ok();
                else return BadRequest();
        }
        [HttpGet("getusers")]
        public async Task<IActionResult> GetUser()
        {         
            return Ok(await _userEntityRepository.GetUsersAsync());
        }
        [HttpPost("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var response = await _userEntityRepository.DeleteAsync(id);
            if (response != null) return Ok();
            return BadRequest();
        }
    }
}