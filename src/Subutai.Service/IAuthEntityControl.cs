using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;
using Subutai.Service.GuidModel;
using static Subutai.Service.AuthEntityControl;

namespace Subutai.Service
{
    public interface IAuthEntityControl
    {
        Task<AuthEntity> LoginAsync(LoginModel loginModel);  
        Task<AuthEntity> RegisterAsync(RegisterModel registerModel);
        Task<AuthEntity> PasswordResetAsync(ResetModel resetModel);
    }
}