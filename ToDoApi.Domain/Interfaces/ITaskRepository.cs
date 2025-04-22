using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApi.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<IEnumerable<TaskItem>> GetFilteredAsync(Status? status, DateTime? dueDate);
        Task AddAsync(TaskItem task);
        void Update(TaskItem task);
        void Remove(TaskItem task);
    }
}
