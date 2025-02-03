using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.EntityFrameworkCore;
using Subutai.Domain.Model;
using Subutai.Domain.Ports;
using Subutai.Repository.SqlRepository.Contexts;
using Subutai.Repository.SqlRepository;
using Subutai.Domain.Ports.DTO;
using System.IO.Compression;
using Microsoft.AspNetCore.Identity;


namespace Subutai.Repository.SqlRepository.Repositories
{
    public class TaskEntityRepository : ITaskEntityRepository
    {
        private readonly SubutaiContext _subutaicontext;
        private readonly UserManager<UserEntity> _userManager;
        private readonly AuthenticationContext _authenticationContext;

        public TaskEntityRepository(SubutaiContext subutaiContext, UserManager<UserEntity> userManager, AuthenticationContext authenticationContext)
        {
            _subutaicontext = subutaiContext;
            _userManager = userManager;
            _authenticationContext = authenticationContext;
        }
        public async Task<TaskEntity> AddTaskAsync(UserTaskDTO userTaskDto)  //öncelik test edilecek
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userTaskDto.UserId);
            var user2 = await _authenticationContext.Users.FirstOrDefaultAsync(x => x.Id == userTaskDto.UserId);
            
            if (user !=null) 
            {                
                    var taskEntity = new TaskEntity()
                    {
                         Name = userTaskDto.TaskName,
                         CreatedAt = DateTime.UtcNow,
                         RedLineTime = userTaskDto.RedLineTime,
                         ExpectDateComplete = DateTime.UtcNow.AddDays(userTaskDto.RedLineTime ?? 0) //null olmayacak.
                    };    
                    await _subutaicontext.Tasks.AddAsync(taskEntity);
                    await _subutaicontext.SaveChangesAsync();

                    var userMapping = new UserTaskMapping(){
                    UserId = userTaskDto.UserId,
                    TaskId = taskEntity.Id
                    };
                    await _subutaicontext.UserTaskMappings.AddAsync(userMapping);
                    await _subutaicontext.SaveChangesAsync();

                    user.ExpectTaskComplete = taskEntity.ExpectDateComplete;
                    user.CurrentWorkload++;
                    
                    await _userManager.UpdateAsync(user);
                    _authenticationContext.Users.Update(user);
                    await _authenticationContext.SaveChangesAsync();
                    await _subutaicontext.SaveChangesAsync();

                    return taskEntity;
            }
            throw new Exception("Kullanıcı bulunamadı.");
        }
        public async Task<TaskEntity> DeleteTaskAsync(TaskEntity taskEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskEntity>> GetTaskAsync(Guid id)
        {
            var UserTaskMap = _subutaicontext.UserTaskMappings.Where(x=>x.UserId == id).ToList();
            var tasks = new List<TaskEntity>();

            foreach (var task in UserTaskMap)
            {
                var response = _subutaicontext.Tasks.Where(x=>x.Id == task.Id).ToList();
                tasks.AddRange(response);
            }
            return tasks;      
        }

        public async Task<TaskEntity> UpdateTaskAsync(TaskEntity taskEntity)
        {
            throw new NotImplementedException();
        }
    }
}