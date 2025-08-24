using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Courses;
using Training_Management_System.DAL.Models.Grades;

namespace Training_Management_System.DAL.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
