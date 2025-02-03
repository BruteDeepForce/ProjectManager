using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;
using Subutai.Domain.Ports.DTO;
using Subutai.Repository.SqlRepository.Contexts;

namespace Subutai.Repository.SqlRepository.Repositories
{
    public class UserTaskFeedbackRepository : IUserTaskFeedbackRepository
    {
        private readonly SubutaiContext _subutaiContext;
        public UserTaskFeedbackRepository(SubutaiContext subutaiContext)
        {
         _subutaiContext = subutaiContext;   
        }
        public async Task<TaskResultDTO> CompleteTask(UserTaskDTO userTaskDTO)
        {
            var taskEntity = await _subutaiContext.Tasks.FirstOrDefaultAsync(x=>x.Id == userTaskDTO.TaskId);
            var user =await _subutaiContext.Users.FirstOrDefaultAsync(x=>x.Id == userTaskDTO.UserId);
            if(taskEntity!=null && user != null)
            {
                if(taskEntity.DateCompleted ==null)
                {
                user.CompletedProjects++;
                user.CurrentWorkload--;
                taskEntity.DateCompleted = DateTime.UtcNow;
                taskEntity.DeletedAt = DateTime.UtcNow;
                await _subutaiContext.SaveChangesAsync();
                return new TaskResultDTO{ DTOtask = taskEntity, DTOuser = user};
                }
                throw new Exception("Task is already completed.");

            }
            throw new Exception("Task or User can not be null");
        }

        public Task<string> FeedbackComment()
        {
            throw new NotImplementedException();
        }

        public Task<int> RequestDelayedTime()
        {
            throw new NotImplementedException();
        }
    }
}