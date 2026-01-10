using Microsoft.AspNetCore.Mvc;

namespace WorkBench.Controllers
{
    [ApiController]
    [Route("Task")]
    public class TaskController : ControllerBase

    {
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok();
        }
    }
}
