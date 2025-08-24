using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training_Management_System.DAL.Models.Courses;
using Training_Management_System.DAL.Presistance.Data;

namespace Training_Management_System.DAL.Presistance.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Course> GetAll(bool WithAsNoTracking = true)
        {
            var query = _dbContext.Courses
                                  .Include(c => c.Instructor); 

            if (WithAsNoTracking)
                return query.AsNoTracking().ToList();

            return query.ToList();
        }

        public Course? GetById(int id)
        {
            return _dbContext.Courses
                             .Include(c => c.Instructor)
                             .FirstOrDefault(c => c.Id == id);
        }
        public int Add(Course course)
        {
            _dbContext.Courses.Add(course);
           return _dbContext.SaveChanges();
        }
        public int Update(Course course)
        {
            _dbContext.Courses.Update(course);
            return _dbContext.SaveChanges();
        }

        public int Delete(Course course)
        {
            _dbContext.Courses.Remove(course);
            return _dbContext.SaveChanges();
        }

        public Course? GetByName(string name)
        {
            return _dbContext.Courses
                            .AsNoTracking()
                            .FirstOrDefault(c => c.Name == name);
        }

        public IEnumerable<Course> Search(string? name, string? category)
        {
            var query = _dbContext.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.Contains(name));

            if (!string.IsNullOrEmpty(category))
                query = query.Where(c => c.Category.Contains(category));

            return query.AsNoTracking().ToList();
        }

        public bool Exists(string name, int? excludeId = null)
        {
            return _dbContext.Courses.Any(c =>
                        c.Name == name && (!excludeId.HasValue || c.Id != excludeId));

        }
    }
}

