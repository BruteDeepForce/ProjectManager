using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subutai.Domain.Ports.DTO
{
    public class UserTaskDTO
    {
        public int UserId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public int? RedLineTime { get; set;}
        public DateTime? ExpectDateComplete { get; set; }

    }
}