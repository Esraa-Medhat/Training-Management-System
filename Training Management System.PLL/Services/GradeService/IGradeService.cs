using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Grades;
using Training_Management_System.DAL.Presistance.Repositories.Grades;
using Training_Management_System.DAL.Presistance.Repositories.Sessions;
using Training_Management_System.PLL.DTOS;

namespace Training_Management_System.PLL.Services.GradeService
{
    public interface IGradeService
    {
        int Create(GradeDto gradeDto);
        int Update(int id, GradeDto gradeDto);
        int Delete(int id);
        GradeDto GetById(int id);
        IEnumerable<GradeDto> GetAll();
        IEnumerable<GradeDto> GetByTraineeId(int traineeId);
        IEnumerable<GradeDto> GetBySessionId(int sessionId);
    }
}
