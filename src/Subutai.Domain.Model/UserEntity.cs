using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Subutai.Domain.Model.Auditing;


namespace Subutai.Domain.Model
{
    public class UserEntity :  IdentityUser<Guid>, IHasCreationTime, IHasDeletionTime, IHasModificationTime
    {       
        public string? Password { get; set; } 
        public float? ExperienceYears { get; set; }
        public float? CompletedProjects { get; set; }
        public int? CurrentWorkload { get; set; } = 0;
        public float? PerformanceRating { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CompleteTaskTime { get; set; }
        public DateTime? ExpectTaskComplete { get; set; }
    }
}