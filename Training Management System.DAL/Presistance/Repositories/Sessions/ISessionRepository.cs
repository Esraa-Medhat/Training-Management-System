using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Sessions;

namespace Training_Management_System.DAL.Presistance.Repositories.Sessions
{
    public interface ISessionRepository
    {
        IEnumerable<Session> GetAll(bool asNoTracking = true);
        Session? GetById(int id);
        int Add(Session session);
        int Update(Session session);
        int Delete(Session session);
        IEnumerable<Session> SearchByCourseName(string courseName);
        bool Exists(int courseId, DateTime startDate, DateTime endDate, int? excludeId = null);
    }
}
