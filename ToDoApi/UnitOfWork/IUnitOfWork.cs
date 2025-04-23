using ToDoApi.Repositories;

namespace ToDoApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
        Task<int> CompleteAsync();

    }
}
