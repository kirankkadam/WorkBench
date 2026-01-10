using WorkBench.ViewModels.Interfaces;

namespace WorkBench.ViewModels
{
    public class Person: IViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}
