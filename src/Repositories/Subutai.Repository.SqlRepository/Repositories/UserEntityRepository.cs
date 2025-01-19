using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;
using Subutai.Repository.SqlRepository.Contexts;

namespace Subutai.Repository.SqlRepository.Repositories
{
    public class UserEntityRepository : IUserEntityRepository
    {
        private readonly ISubutaiContext _context;
        
        public UserEntityRepository(ISubutaiContext context)
        {
                _context = context;
        }
        public async Task<UserEntity> AddAsync(UserEntity userEntity)
        {
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return userEntity;
        }

        public Task<UserEntity> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> UpdateAsync(UserEntity userEntity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}