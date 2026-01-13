using System.ComponentModel.DataAnnotations.Schema;
using IModel = WorkBench.Models.Interfaces.IModel;

namespace WorkBench.Models
{
    [Table("Tasks")]
    public class TaskItem: IModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation property
        public List<Timesheet> Timesheets { get; set; } = new();
    }
}
