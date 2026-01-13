using System.ComponentModel.DataAnnotations.Schema;

namespace WorkBench.Models
{
    [Table("Timesheets")]
    public class Timesheet
    {
        public int Id { get; set; }
        public int PersonId { get; set; } // Foreign Key to Person
        public int TaskId { get; set; } // Foreign Key to Task
        public string Comment { get; set; } = string.Empty;
        public DateTime ExecutedOn { get; set; }
        public decimal HoursWorked { get; set; }

        // Navigation properties
        public Person Person { get; set; } = null!;
        public TaskItem Task { get; set; } = null!;
    }
}
