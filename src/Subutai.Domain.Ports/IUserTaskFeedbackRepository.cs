using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subutai.Domain.Model;
using Subutai.Domain.Ports.DTO;

namespace Subutai.Domain.Ports
{
    public interface IUserTaskFeedbackRepository
    {
        public Task<string> FeedbackComment ();
        public Task<TaskResultDTO> CompleteTask (UserTaskDTO userTaskDTO);
        public Task<int> RequestDelayedTime ();
    }
}