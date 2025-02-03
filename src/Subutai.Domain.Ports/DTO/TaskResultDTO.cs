using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;

namespace Subutai.Domain.Ports.DTO
{
    public class TaskResultDTO
    {
        public UserEntity? DTOuser;
        public TaskEntity? DTOtask;
    }
}