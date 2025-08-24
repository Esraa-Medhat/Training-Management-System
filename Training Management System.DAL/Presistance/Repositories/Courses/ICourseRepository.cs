using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Courses;

namespace Training_Management_System.DAL.Presistance.Repositories.Courses
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll(bool WithAsNoTracking=true);
        Course? GetById(int id);
        int Add(Course course);
        int Update(Course course);
        int Delete(Course course);
        Course? GetByName(string name);
        IEnumerable<Course> Search(string? name, string? category);
        bool Exists(string name, int? excludeId = null);
    }
}
