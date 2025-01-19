using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<UserEntity> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e=> e.Id == id);

            if (user != null) 
            {
                user.DeletedAt = DateTime.UtcNow; 
                await _context.SaveChangesAsync();
                return user; 
            }
            throw new ArgumentException("Entity is not found");

        }

        public Task<UserEntity> UpdateAsync(UserEntity userEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserEntity>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            var unDeletedUsers = users.Where(e=> e.DeletedAt == null).ToList();
            return unDeletedUsers;
        }
    }
}