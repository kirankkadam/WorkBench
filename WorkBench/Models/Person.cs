namespace WorkBench.Models
{
    using System.Collections.Generic;
    using IModel = Interfaces.IModel;

    public class Person: IModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        // Navigation property
        public List<Timesheet> Timesheets { get; set; } = new();
    }
}
