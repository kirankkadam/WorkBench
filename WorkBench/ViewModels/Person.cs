using System.ComponentModel.DataAnnotations;
using WorkBench.ViewModels.Interfaces;

namespace WorkBench.ViewModels
{
    public class Person: IViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a full name")]
        [MinLength(3, ErrorMessage = "Name should have minimum 3 characters")]
        public string FullName { get; set; } = string.Empty;
    }
}
