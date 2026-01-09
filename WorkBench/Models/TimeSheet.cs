namespace WorkBench.Models
{
    public class Timesheet
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign Key to Person
        public int TaskId { get; set; } // Foreign Key to Task
        public string Comment { get; set; } = string.Empty;
        public DateTime ExecutedOn { get; set; }

        // Navigation properties
        public Person Person { get; set; } = null!;
        public TaskItem Task { get; set; } = null!;
    }
}
