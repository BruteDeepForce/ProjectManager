using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Subutai.Domain.Model;

namespace Subutai.Repository.SqlRepository.Contexts
{
    public class AuthenticationContext : IdentityDbContext<UserEntity, AppRoleEntity, Guid>
    {
        public DbSet<UserEntity> UserAuthEntities { get; set; }
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
        }
        protected AuthenticationContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}