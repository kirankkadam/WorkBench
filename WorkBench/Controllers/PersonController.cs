using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkBench.DB;
using WorkBench.ViewModels;

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

        [HttpPost("AddNewPerson")]
        public async Task<IActionResult> AddNewPerson([FromBody] Person newPerson)
        {
            if (newPerson is null)
            {
                return BadRequest();
            }
            var personModel = new Models.Person
            {
                FullName = newPerson.FullName
            };
            _workBenchDbContext.Persons.Add(personModel);
            _workBenchDbContext.SaveChanges();

            return Ok(newPerson);
        }
    }
}
