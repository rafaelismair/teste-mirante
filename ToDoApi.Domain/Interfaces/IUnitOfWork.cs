namespace ToDoApi.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
        Task CommitAsync();
    }

}
