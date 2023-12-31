﻿using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface ITaskRepository
    {
        Task<Tasks> AddAsync(Tasks task);
        Task<Tasks> UpdateAsync(Tasks task);
        Task<Tasks> GetTaskAsync(Guid userId);
        Task<IList<Tasks>> GetAsync(Guid userId, Status status = Status.Pending, Priority priority = Priority.Low);
        Task<IList<Tasks>> FetchUserDueTasksOfTheWeek(Guid userId);
        Task<IList<Tasks>> GetAsync(Guid userId);
        Task<bool> ExitsAsync(Guid id);
        Task<bool> DeleteAsync(Tasks task);
        Task<ProjectTasks> AssignTaskToProject(Guid taskId, Guid projectId);
        Task<IList<Tasks>> GetTasksDueWithin48HoursAsync();
        Task<IList<Tasks>> GetTasksBasedOnTheirPriorityOrStatus(Priority priority, Status status);
        
    }
}
