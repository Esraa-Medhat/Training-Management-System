using System.ComponentModel.DataAnnotations;

namespace Training_Management_Sysytem.PL.Models.Courses
{
    public class CourseEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required !")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Category is Required !")]
        public string Category { get; set; } = null!;
        [Required(ErrorMessage = "InstructorName is Required !")]
        public string InstructorName { get; set; } = null!;
    }
}
