using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;
using Subutai.Service;

namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IUserAuthentication _userAuthentication;
        public LoginController(IUserAuthentication userAuthentication)
        {
                _userAuthentication = userAuthentication;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserEntity user)
        {
            var IsUserExist = await _userAuthentication.UserControlAsync(user);
            if (IsUserExist) return Ok();
            return Unauthorized();
        }
    }

}