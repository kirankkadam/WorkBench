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
    }
}
