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

namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AuthEntity> _userManager;

        public LoginController(UserManager<AuthEntity> userManager)
        {
            _userManager = userManager;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken cancellationToken)
        {
            
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var userEntity = await _userManager.FindByEmailAsync(model.Email);
            if (userEntity == null || !await _userManager.CheckPasswordAsync(userEntity, model.Password))
            {
                return Unauthorized();
            }
            return Ok();

        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userEntity = new AuthEntity
            {
                UserName = model.UserName,
                Email = model.Email,
                
            };

            var result = await _userManager.CreateAsync(userEntity, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
        [HttpPost("resetpass")]
        public async Task<IActionResult> ResetPassword(reset reset)
        {

            var user = await _userManager.FindByEmailAsync(reset.mail);

            if (user != null)
            {
                var generatedToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, reset.password, generatedToken);
                return Ok();

            }
            return BadRequest();

        }

        public record reset (string mail, string password);

    }
}