using Microsoft.AspNetCore.Mvc;
using WorkBench.DB;

namespace WorkBench.Controllers
{
    [ApiController]
    [Route("Task")]
    public class TaskController : ControllerBase
    {
        private WorkBenchDbContext _workBenchDbContext;
        public TaskController(WorkBenchDbContext workBenchDbContext)
        {
            _workBenchDbContext = workBenchDbContext;
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = _workBenchDbContext.Tasks?.ToList();
            if(tasks is null)
            {
                return NotFound();
            }

            var taskViewModels = tasks.Select(t => new ViewModels.Task
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description
            }).ToList();

            return Ok(taskViewModels);
        }

        [HttpPost("AddNewTask")]
        public async Task<IActionResult> AddNewTask([FromBody] ViewModels.Task newTask)
        {
            if (newTask == null)
            {
                return BadRequest("Task data is null.");
            }

            var taskEntity = new Models.TaskItem
            {
                Title = newTask.Title,
                Description = newTask.Description
            };

            _workBenchDbContext.Tasks.Add(taskEntity);
            await _workBenchDbContext.SaveChangesAsync();
            newTask.Id = taskEntity.Id;
            return Ok(newTask);
        }
    }
}
