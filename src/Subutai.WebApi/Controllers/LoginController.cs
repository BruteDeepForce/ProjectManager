using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly SignInManager<UserEntity> _signInManager;
        public LoginController(UserManager<AuthEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var userEntity = await _userManager.FindByEmailAsync(model.Email);
            if (userEntity == null || !await _userManager.CheckPasswordAsync(userEntity, model.Password))
            {
                return Unauthorized();
            }
            return Ok();

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
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

    }
}