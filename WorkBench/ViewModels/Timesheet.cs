using System.ComponentModel.DataAnnotations;
using WorkBench.ViewModels.Interfaces;

namespace WorkBench.ViewModels
{
    public class Timesheet : IViewModel
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Please select a task id")]
        public int TaskId { get; set; }
        public string? TaskTitle { get; set; }

        [Required(ErrorMessage ="Please select a user id")]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Comment { get; set; }
        public DateTime ExecutedOn { get; set; }
        public decimal HoursWorked { get; set; }
    }
}
