using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoDbContext _context;

        public ITaskRepository Tasks { get; }

        public UnitOfWork(ToDoDbContext context)
        {
            _context = context;
            Tasks = new TaskRepository(_context);
        }

        public async Task CommitAsync() => await _context.SaveChangesAsync();
    }
}
