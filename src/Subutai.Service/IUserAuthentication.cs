using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;

namespace Subutai.Service
{
    public interface IUserAuthentication
    {
        Task<bool> UserControlAsync(UserEntity userEntity);
    }
}