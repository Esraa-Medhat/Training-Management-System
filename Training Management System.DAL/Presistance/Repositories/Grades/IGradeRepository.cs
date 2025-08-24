using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Grades;

namespace Training_Management_System.DAL.Presistance.Repositories.Grades
{
    public interface IGradeRepository
    {

        IEnumerable<Grade> GetAll();
        Grade GetById(int id);
        IEnumerable<Grade> GetByTraineeId(int traineeId);
        int Add(Grade grade);
        int Update(int id,Grade grade);
        int Delete(int id);
        IEnumerable<Grade> GetBySessionId(int sessionId);
        IEnumerable<Grade> GetAllWithDetails();
    }
}
