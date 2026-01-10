using WorkBench.ViewModels.Interfaces;

namespace WorkBench.ViewModels
{
    public class Task : IViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
