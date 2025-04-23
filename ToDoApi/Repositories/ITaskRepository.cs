using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem> GetByIdAsync(int id);
        Task<IEnumerable<TaskItem>> FilterAsync(Models.TaskStatus? status, DateTime? dueDate);
        Task AddAsync(TaskItem task);
        void Update(TaskItem task);
        void Remove(TaskItem task);
    }
}
