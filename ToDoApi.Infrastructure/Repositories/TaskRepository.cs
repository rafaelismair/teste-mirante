using Microsoft.EntityFrameworkCore;
using ToDoApi.Domain;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoDbContext _context;

        public TaskRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id) =>
            await _context.Tasks.FindAsync(id);

        public async Task<IEnumerable<TaskItem>> GetAllAsync() =>
            await _context.Tasks.ToListAsync();

        public async Task<IEnumerable<TaskItem>> GetFilteredAsync(Status? status, DateTime? dueDate)
        {
            var query = _context.Tasks.AsQueryable();
            if (status.HasValue)
                query = query.Where(t => t.Status == status);
            if (dueDate.HasValue)
                query = query.Where(t => t.DueDate.Date == dueDate.Value.Date);
            return await query.ToListAsync();
        }

        public async Task AddAsync(TaskItem task) => await _context.Tasks.AddAsync(task);

        public void Update(TaskItem task) => _context.Tasks.Update(task);

        public void Remove(TaskItem task) => _context.Tasks.Remove(task);
    }
}
