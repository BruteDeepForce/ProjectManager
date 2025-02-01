using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model.Auditing;

namespace Subutai.Domain.Model
{
    public class TaskEntity : IHasCreationTime, IHasModificationTime, IHasDeletionTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProjectEntity? Project { get; set; }
        public UserEntity? User { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? DateCompleted {get;set;} 
        public int? UserNumber { get; set;}
        public int? RedLineTime { get; set;}
        public DateTime? ExpectDateComplete { get; set; }
    }
}