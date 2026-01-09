namespace WorkBench.Models
{
    using System.Collections.Generic;

    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        // Navigation property
        public List<Timesheet> Timesheets { get; set; } = new();
    }
}
