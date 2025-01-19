using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;

namespace Subutai.Domain.Ports
{
    public interface IUserEntityRepository
    {
        public Task<UserEntity> AddAsync (UserEntity userEntity);
        public Task<UserEntity> UpdateAsync (UserEntity userEntity);
        public Task<UserEntity> DeleteAsync (int id);

        public Task<UserEntity> GetUsersAsync ();
    }
}