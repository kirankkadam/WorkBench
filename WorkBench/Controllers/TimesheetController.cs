using Microsoft.AspNetCore.Mvc;

namespace WorkBench.Controllers
{
    [ApiController]
    [Route("Timesheet")]
    public class TimesheetController : ControllerBase
    {
        [HttpGet("GetAllTimesheets")]
        public async Task<IActionResult> GetAllTimesheets()
        {
            return Ok("");
        }
    }
}
