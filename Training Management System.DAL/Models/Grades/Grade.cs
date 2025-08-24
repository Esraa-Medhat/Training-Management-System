using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using Training_Management_System.DAL.Models.Users;
using Training_Management_System.DAL.Models.Sessions;

namespace Training_Management_System.DAL.Models.Grades
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        public int SessionId { get; set; }
        public Session Session { get; set; }

        [Required]
        public int TraineeId { get; set; }
        public User Trainee { get; set; }

        [Required, Range(0, 100)]
        public int Value { get; set; }
    }
}
