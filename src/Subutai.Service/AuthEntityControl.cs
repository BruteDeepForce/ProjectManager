using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;
using Subutai.Service.GuidModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using Microsoft.VisualBasic;
using Microsoft.Extensions.DependencyInjection;

namespace Subutai.Service
{
    public class AuthEntityControl : IAuthEntityControl
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        public AuthEntityControl(UserManager<UserEntity> userManager, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _userManager = userManager;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }
        public async Task<string> LoginAsync(LoginModel loginModel)  //yapılandırıldı
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return "Invalid email or password"!;
            }
            //var generatedToken = await GenerateToken(loginModel.Email);

            //return generatedToken;

            return "Login Success";
        }
        public async Task<UserEntity> PasswordResetAsync(ResetModel resetModel) //yapılandırılmadı
        {
            var user = await _userManager.FindByEmailAsync(resetModel.Email);

            if (user != null)
            {
                return null!;
            }

            string? generatedToken = await _userManager.GeneratePasswordResetTokenAsync(user!);

            var resetLink = $"https://localhost:5001/api/login/resetpassword?email={resetModel.Email}&token={generatedToken}";

            //mail burada gönderilecek. Maildeki link üzerinden generate new password sayfasına yönlendirilecek.
            return user!;

        }
        public async Task<UserEntity> RegisterAsync(RegisterModel registerModel) //yapılandırıldı
        {
            if(registerModel == null) return null!;

            var user = new UserEntity
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email
                
            }; 
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            //await CreateRoles(_serviceProvider);
            //var res2 = await _userManager.AddToRoleAsync(user, registerModel.Role);

            if (!result.Succeeded) return null!;
            return user;          
        }
        
        public record ResetModel(string Email);
        private async Task<string> GenerateToken(string email)
        {
         var jwtSettings = _configuration.GetSection("Jwt");
         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));

          var user = await _userManager.FindByEmailAsync(email);  //rol için standby şuan
          var roles = await _userManager.GetRolesAsync(user!);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // new Claim("Role", userRole)  //Claimden Role bilgisini ekliyoruz
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                 var token = new JwtSecurityToken(
                 issuer: jwtSettings["Issuer"],
                 audience: jwtSettings["Audience"],
                 expires: DateTime.UtcNow.AddSeconds(90),
                 signingCredentials: credentials,
                 claims : claims
                 
            ); 

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task CreateRoles(IServiceProvider serviceProvider)  //gerektiğinde kullanılacak
        {
                using(var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRoleEntity>>())
                {var roles = new List<AppRoleEntity>()
                {
                    new AppRoleEntity(){ Name ="ADMIN"},
                    new AppRoleEntity(){ Name ="MANAGER"},
                    new AppRoleEntity() { Name ="USER"}
                };
                    foreach (var role in roles)
                    {
                         await roleManager.CreateAsync(role);
                     }
                }
                // roles.ForEach(role => role.Name = role)

        }
    }
}