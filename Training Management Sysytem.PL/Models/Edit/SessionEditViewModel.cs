using System.ComponentModel.DataAnnotations;

namespace Training_Management_Sysytem.PL.Models.Courses
{
    public class SessionEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public int CourseId { get; set; }

        public string? CourseName { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
