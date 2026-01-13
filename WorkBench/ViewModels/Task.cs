using System.ComponentModel.DataAnnotations;
using WorkBench.ViewModels.Interfaces;

namespace WorkBench.ViewModels
{
    public class Task : IViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
