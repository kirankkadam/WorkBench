using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkBench.DB;

namespace WorkBench.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : ControllerBase
    {
        private readonly WorkBenchDbContext _workBenchDbContext;
        public PersonController(WorkBenchDbContext workBenchDbContext)
        {
            _workBenchDbContext = workBenchDbContext;
        }

        [HttpGet("GetAllPeople")]
        public async Task<IActionResult> GetAllPeople()
        {
            var people = _workBenchDbContext.Persons?.ToListAsync();
            if(people is null)
            {
                return NotFound();
            }

            var result = new List<ViewModels.Person>();
            foreach (var person in await people)
            {
                var personViewModel = new ViewModels.Person
                {
                    Id = person.Id,
                    FullName = person.FullName
                };

                result.Add(personViewModel);
            }
            return Ok(result);
        }
    }
}
