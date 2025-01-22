using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;
using Subutai.Service.GuidModel;
using Microsoft.AspNetCore.Identity;

namespace Subutai.Service
{
    public class AuthEntityControl : IAuthEntityControl
    {
        public Task<AuthEntity> LoginAsync(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<AuthEntity> PasswordResetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthEntity> RegisterAsync(RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }
    }
}