using Microsoft.EntityFrameworkCore;
using ToDoApi.Repositories;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.Tests.Repositories
{
    public class TaskRepositoryTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // sempre novo
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task AddAsync_ShouldAddTask()
        {
            // Arrange
            var context = GetDbContext();
            var repository = new TaskRepository(context);

            var task = new TaskItem
            {
                Title = "Test Task",
                Description = "Testing add",
                Status = Models.TaskStatus.Pending,
                DueDate = DateTime.Today.AddDays(1)
            };

            // Act
            await repository.AddAsync(task);
            await context.SaveChangesAsync();

            // Assert
            var inserted = await context.Tasks.FirstOrDefaultAsync();
            Assert.NotNull(inserted);
            Assert.Equal("Test Task", inserted.Title);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTask_WhenTaskExists()
        {
            // Arrange
            var context = GetDbContext();
            var repository = new TaskRepository(context);

            var task = new TaskItem
            {
                Title = "Task for get",
                Description = "Testing get",
                Status = Models.TaskStatus.Pending,
                DueDate = DateTime.Today.AddDays(2)
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            // Act
            var foundTask = await repository.GetByIdAsync(task.Id);

            // Assert
            Assert.NotNull(foundTask);
            Assert.Equal(task.Title, foundTask.Title);
        }
    }
}
