using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Subutai.Domain.Model;
using Subutai.Domain.Ports.DTO;


namespace Subutai.Domain.Ports
{
    public interface ITaskEntityRepository
    {
        public Task<List<TaskEntity>> GetTaskAsync(int id);
        public Task<TaskEntity> AddTaskAsync(UserTaskDTO userTaskDto);
        public Task<TaskEntity> UpdateTaskAsync(TaskEntity taskEntity);
        public Task<TaskEntity> DeleteTaskAsync(TaskEntity taskEntity);
        
    }
}