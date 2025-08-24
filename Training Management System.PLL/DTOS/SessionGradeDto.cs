using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Management_System.PLL.DTOS
{
    public class SessionGradeDto
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; } = string.Empty;
        public int GradeValue { get; set; }
    }
}
