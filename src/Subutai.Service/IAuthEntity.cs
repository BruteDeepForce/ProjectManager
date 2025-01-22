using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;
using Subutai.Service.GuidModel;

namespace Subutai.Service
{
    public interface IAuthEntityControl
    {
        Task<AuthEntity> LoginAsync(LoginModel loginModel);  
        Task<AuthEntity> RegisterAsync(RegisterModel registerModel);

        Task<AuthEntity> PasswordResetAsync();
    }
}