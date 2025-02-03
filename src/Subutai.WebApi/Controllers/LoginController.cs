using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;
using Subutai.Service;
using Subutai.Service.GuidModel;
using static Subutai.Service.AuthEntityControl;

namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IAuthEntityControl _authEntityControl;

        public LoginController(UserManager<UserEntity> userManager, IAuthEntityControl authEntityControl)
        {
            _userManager = userManager;
            _authEntityControl = authEntityControl;

        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken cancellationToken)
        {
            
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _authEntityControl.LoginAsync(model);

            if (response == null) return BadRequest("Invalid email or password");
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _authEntityControl.RegisterAsync(model);
            
            if (response == null) return BadRequest("User already exists");

            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("resetpass")]
        public async Task<IActionResult> ResetPassword(ResetModel resetModel)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _authEntityControl.PasswordResetAsync(resetModel);
            
            return Ok();
        }
    }
}