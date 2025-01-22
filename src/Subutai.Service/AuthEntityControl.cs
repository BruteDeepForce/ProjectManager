using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;
using Subutai.Service.GuidModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Subutai.Service
{
    public class AuthEntityControl : IAuthEntityControl
    {
        private readonly UserManager<AuthEntity> _userManager;

        public AuthEntityControl(UserManager<AuthEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> LoginAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return null;
            }
            var generatedToken = await _userManager.GenerateUserTokenAsync(user, "Default", "login");
            return generatedToken;
        }
        public async Task<AuthEntity> PasswordResetAsync(ResetModel resetModel)
        {
            var user = await _userManager.FindByEmailAsync(resetModel.Email);

            if (user != null)
            {
                return null;
            }

            var generatedToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = $"https://localhost:5001/api/login/resetpassword?email={resetModel.Email}&token={generatedToken}";

            //mail burada gönderilecek. Maildeki link üzerinden generate new password sayfasına yönlendirilecek.
            return user;

        }
        public async Task<AuthEntity> RegisterAsync(RegisterModel registerModel)
        {
            if(registerModel == null) return null;

            var user = new AuthEntity
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
            }; 
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded) return null;
            return user;          
        }
        public record ResetModel(string Email);
    }
}