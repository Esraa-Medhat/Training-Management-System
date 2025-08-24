using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training_Management_System.DAL.Models.Sessions;
using Training_Management_System.DAL.Presistance.Data;

namespace Training_Management_System.DAL.Presistance.Repositories.Sessions
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AppDbContext _dbContext;

        public SessionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Session> GetAll(bool asNoTracking = true)
        {
            var query = _dbContext.Sessions.Include(s => s.Course).AsQueryable();
            if (asNoTracking) query = query.AsNoTracking();
            return query.ToList();
        }

        public Session? GetById(int id)
        {
            return _dbContext.Sessions.Include(s => s.Course).FirstOrDefault(s => s.Id == id);
        }

        public int Add(Session session)
        {
            _dbContext.Sessions.Add(session);
            return _dbContext.SaveChanges();
        }

        public int Update(Session session)
        {
            _dbContext.Sessions.Update(session);
            return _dbContext.SaveChanges();
        }

        public int Delete(Session session)
        {
            _dbContext.Sessions.Remove(session);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Session> SearchByCourseName(string courseName)
        {
            return _dbContext.Sessions
                .Include(s => s.Course)
                .Where(s => s.Course != null && s.Course.Name.Contains(courseName))
                .AsNoTracking()
                .ToList();
        }

        public bool Exists(int courseId, DateTime startDate, DateTime endDate, int? excludeId = null)
        {
            return _dbContext.Sessions.Any(s =>
                s.CourseId == courseId &&
                s.Id != excludeId &&
                ((startDate >= s.StartDate && startDate <= s.EndDate) ||
                 (endDate >= s.StartDate && endDate <= s.EndDate)));
        }
    }
}
