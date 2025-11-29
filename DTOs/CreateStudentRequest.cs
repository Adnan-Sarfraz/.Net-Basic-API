
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs
{
    public class CreateStudentRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = "";

        [Range(5, 100, ErrorMessage = "Age must be between 5 and 100")]
        public int Age { get; set; }
    }
}
