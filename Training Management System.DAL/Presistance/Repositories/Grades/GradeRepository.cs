using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training_Management_System.DAL.Models.Grades;
using Training_Management_System.DAL.Presistance.Data;
using Training_Management_System.DAL.Presistance.Repositories.Grades;

namespace Training_Management_System.DAL.Presistance.Repositories.Grades
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _dbContext;

        public GradeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Grade> GetAll()
        {
            return _dbContext.Grades.ToList();
        }
        public IEnumerable<Grade> GetAllWithDetails()
        {
            return _dbContext.Grades
                .Include(g => g.Trainee)
                .Include(g => g.Session)
                .AsNoTracking()
                .ToList();
        }


        public Grade GetById(int id)
        {
            return _dbContext.Grades.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<Grade> GetByTraineeId(int traineeId)
        {
            return _dbContext.Grades.Where(g => g.TraineeId == traineeId).ToList();
        }

        public int Add(Grade grade)
        {
            _dbContext.Grades.Add(grade);
            return _dbContext.SaveChanges();
        }

        public int Update(int id,Grade grade)
        {
            _dbContext.Grades.Update(grade);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var grade = _dbContext.Grades.FirstOrDefault(g => g.Id == id);
            if (grade != null)
            {
                _dbContext.Grades.Remove(grade);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Grade> GetBySessionId(int sessionId)
        {
            return _dbContext.Grades
                             .Where(g => g.SessionId == sessionId)
                             .AsNoTracking()
                             .ToList();
        }

    }
}