using Microsoft.AspNetCore.Mvc;
using WorkBench.DB;
using WorkBench.Models;
using WorkBench.Repository.Interfaces;

namespace WorkBench.Controllers
{
    [ApiController]
    [Route("Timesheet")]
    public class TimesheetController : ControllerBase
    {
        private WorkBenchDbContext _workBenchDbContext;
        private readonly IRepository<Timesheet> _workBenchRepository;
        public TimesheetController(WorkBenchDbContext workBenchDbContext, IRepository<Timesheet> workBenchRepository)
        {
            _workBenchDbContext = workBenchDbContext;
            _workBenchRepository = workBenchRepository;
        }

        [HttpGet("GetAllTimesheets")]
        public async Task<IActionResult> GetAllTimesheets()
        {
            var listOfTimesheets = await _workBenchRepository.GetAllAsync();
            if (listOfTimesheets is null)
            {
                return NotFound();
            }

            var timesheetViewModels = listOfTimesheets.Select(t => new ViewModels.Timesheet
            {
                Id = t.Id,
                UserId = t.PersonId,
                UserName = _workBenchDbContext.Persons.FirstOrDefault(person => person.Id == t.PersonId)?.FullName,
                TaskId = t.TaskId,
                TaskTitle = _workBenchDbContext.Tasks.FirstOrDefault(task => task.Id == t.TaskId)?.Title,
                Comment = t.Comment,
                ExecutedOn = t.ExecutedOn,
                HoursWorked = t.HoursWorked
            }).ToList();

            return Ok(timesheetViewModels);
        }

        [HttpGet("GetTimesheet/{id}")]
        public async Task<IActionResult> GetTimesheetById(int id)
        {
            var timesheet = await _workBenchRepository.GetByIdAsync(id);
            if (timesheet is null)
            {
                return NotFound();
            }

            var timesheetViewModel = new ViewModels.Timesheet
            {
                Id = timesheet.Id,
                UserId = timesheet.PersonId,
                TaskId = timesheet.TaskId,
                Comment = timesheet.Comment,
                ExecutedOn = timesheet.ExecutedOn
            };

            return Ok(timesheetViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddTimesheet([FromBody] ViewModels.Timesheet timesheet)
        {
            if(timesheet == null || timesheet.UserId <= 0 || timesheet.TaskId <= 0)
            {
                return BadRequest("Bad timesheet data.");
            }

            var newTimesheet = new Models.Timesheet
            {
                PersonId = timesheet.UserId,
                TaskId = timesheet.TaskId,
                Comment = timesheet.Comment,
                ExecutedOn = timesheet.ExecutedOn,
                HoursWorked = timesheet.HoursWorked
            };
            await _workBenchRepository.AddAsync(newTimesheet);
            _workBenchDbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTimesheet(ViewModels.Timesheet timesheet)
        {
            if (timesheet == null || timesheet.Id <= 0)
            {
                return BadRequest("Bad timesheet data.");
            }

            var timehseetInDb = await _workBenchRepository.GetByIdAsync(timesheet.Id);
            if(timehseetInDb is null)
            {
                return NotFound();
            }

            await _workBenchRepository.DeleteAsync(timesheet.Id);
            return Ok();
        }
    }
}
