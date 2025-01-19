using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Subutai.Domain.Model;
using Subutai.Repository.SqlRepository.Contexts;

namespace Subutai.Service
{
    public class UserAuthentication : IUserAuthentication
    {
        private readonly ISubutaiContext _subutaiContext;
        public UserAuthentication(ISubutaiContext subutaiContext)
        {
            _subutaiContext = subutaiContext;
        }
        public async Task<bool> UserControlAsync(UserEntity userEntity)
        {
            var user = await _subutaiContext.Users.FirstOrDefaultAsync(e=> e.Email == userEntity.Email && e.Password == userEntity.Password);
            
            if(user != null) return true;
            return false;

        }
    }
}