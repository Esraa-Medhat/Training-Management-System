using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Management_System.PLL.DTOS
{
    public class CourseDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required !")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Category is Required !")]
        public string Category { get; set; } = null!;
        [Required(ErrorMessage = "InstructorName is Required !")]
        public string InstructorName { get; set; } = null!;
        public int TraineeId { get; set; }
    }
}
