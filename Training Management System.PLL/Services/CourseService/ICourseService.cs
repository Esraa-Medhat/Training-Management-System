using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.PLL.DTOS;

namespace Training_Management_System.PLL.Services.Course
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAll();
        CourseDto? GetCourseById(int id);
        int CreateCourse(CourseDto courseDto);
        int UpdateCourse(CourseDto courseDto);
        bool DeleteCourse(int id);
        IEnumerable<CourseDto> SearchCourses(string? name, string? category);
        CourseDto? GetByName(string name);

    }
}
