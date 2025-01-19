using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Subutai.Domain.Model;

namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        List<UserEntity> users;
        public LoginController()
        {
        users = new List<UserEntity>
        {
            new UserEntity {Username = "admin", Password = "1234", Id = 1, Email = "admin@gmail.com"}
        };
     }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserEntity user)
        {
            var userEntity = users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (userEntity == null)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }

}