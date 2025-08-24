using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Management_System.PLL.DTOS
{
    public class GradeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Session is required")]
        public int SessionId { get; set; }
        public string? SessionName { get; set; }

        [Required(ErrorMessage = "Trainee is required")]
        public int TraineeId { get; set; }
        public string? TraineeName { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        public int Value { get; set; }
      
    }
}