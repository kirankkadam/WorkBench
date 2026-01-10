using Microsoft.AspNetCore.Mvc;

namespace WorkBench.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : ControllerBase
    {
        [HttpGet("GetAllPeople")]
        public async Task<IActionResult> GetAllPeople()
        {
            return Ok();
        }
    }
}
