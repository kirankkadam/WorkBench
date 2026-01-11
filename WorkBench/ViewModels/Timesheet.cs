using WorkBench.ViewModels.Interfaces;

namespace WorkBench.ViewModels
{
    public class Timesheet : IViewModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
