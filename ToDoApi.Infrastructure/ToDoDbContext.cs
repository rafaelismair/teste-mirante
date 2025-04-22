using Microsoft.EntityFrameworkCore;
using ToDoApi.Domain;

namespace ToDoApi.Infrastructure
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}