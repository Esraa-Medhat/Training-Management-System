using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Users;

namespace Training_Management_System.DAL.Models.Courses
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;
        [Required]
        public int InstructorId { get; set; }   
        public User Instructor { get; set; }



    }
}

