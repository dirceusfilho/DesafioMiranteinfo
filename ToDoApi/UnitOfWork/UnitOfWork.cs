using ToDoApi.Data;
using ToDoApi.Repositories;

namespace ToDoApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ITaskRepository Tasks { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Tasks = new TaskRepository(context); // Instancia diretamente o repositório
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
