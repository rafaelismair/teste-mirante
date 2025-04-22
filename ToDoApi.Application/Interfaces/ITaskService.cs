using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain;

namespace ToDoApi.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync(Status? status, DateTime? dueDate);
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<TaskItem> CreateAsync(TaskItem task);
        Task<bool> UpdateAsync(Guid id, TaskItem task);
        Task<bool> DeleteAsync(Guid id);
    }

}
