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

        public int TaskId { get; set; } = 0;
        public int? RedLineTime { get; set;}
    }
}