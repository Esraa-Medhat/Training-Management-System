using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Courses;
using Training_Management_System.DAL.Models.Grades;

namespace Training_Management_System.DAL.Models.Sessions
{
    public class Session
    {
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
