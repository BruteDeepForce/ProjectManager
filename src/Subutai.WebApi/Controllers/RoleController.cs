using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Subutai.Domain.Model;

namespace Subutai.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<AppRoleEntity> _roleManager;

        public RoleController(RoleManager<AppRoleEntity> roleManager)
        {
          _roleManager = roleManager;   
        }

        [HttpGet("getroles")]
         public IActionResult GetRoles()
         {
            var roles = _roleManager.Roles;

            return Ok(roles); 
         }
    }


}