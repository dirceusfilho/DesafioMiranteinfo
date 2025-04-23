using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.UnitOfWork;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _unitOfWork.Tasks.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] Models.TaskStatus? status, [FromQuery] DateTime? dueDate)
        {
            var tasks = await _unitOfWork.Tasks.FilterAsync(status, dueDate);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem updatedTask)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (task == null) return NotFound();

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Status = updatedTask.Status;
            task.DueDate = updatedTask.DueDate;

            _unitOfWork.Tasks.Update(task);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (task == null) return NotFound();

            _unitOfWork.Tasks.Remove(task);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
