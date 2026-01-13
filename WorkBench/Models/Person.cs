namespace WorkBench.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using IModel = Interfaces.IModel;

    [Table("People")]
    public class Person: IModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        // Navigation property
        public List<Timesheet> Timesheets { get; set; } = new();
    }
}
