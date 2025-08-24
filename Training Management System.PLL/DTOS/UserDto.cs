using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Management_System.PLL.DTOS
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required !")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is Required !")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Role is Required !")]
        public string Role { get; set; } = null!;
    }
}
