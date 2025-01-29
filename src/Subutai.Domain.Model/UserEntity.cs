using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model.Auditing;

namespace Subutai.Domain.Model
{
    public class UserEntity : IHasCreationTime, IHasDeletionTime, IHasModificationTime
    {       
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } 
        public string? Email { get; set; }
        public float? ExperienceYears { get; set; }
        public float? CompletedProjects { get; set; }
        public float? TaskEfficiency { get; set; }
        public float? CurrentWorkload { get; set; }
        public float? PerformanceRating { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UniqueId { get; set; }
    }
}