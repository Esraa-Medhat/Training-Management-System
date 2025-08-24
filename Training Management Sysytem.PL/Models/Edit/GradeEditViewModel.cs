using System.ComponentModel.DataAnnotations;

namespace Training_Management_Sysytem.PL.Models.Edit
{
    public class GradeEditViewModel
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
