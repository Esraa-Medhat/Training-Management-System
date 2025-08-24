using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Courses;
using Training_Management_System.DAL.Presistance.Repositories.Courses;
using Training_Management_System.DAL.Presistance.Repositories.Users;
using Training_Management_System.PLL.DTOS;

namespace Training_Management_System.PLL.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public CourseService( ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<CourseDto> GetAll()
        {
            var courses = _courseRepository.GetAll();
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Category = c.Category,
                InstructorName = c.Instructor?.Name ?? "Unknown"
            }).ToList();
        }

        public CourseDto? GetCourseById(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null) return null;

            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Category = course.Category,
                InstructorName = course.Instructor?.Name ?? "Unknown"
            };
        }
        public int CreateCourse(CourseDto courseDto)
        {
            var instructor = _userRepository.GetByName(courseDto.InstructorName);
            if (instructor == null)
                throw new InvalidOperationException("Instructor not found.");

            if (_courseRepository.Exists(courseDto.Name))
                throw new InvalidOperationException("Course with the same name already exists.");

            var course = new DAL.Models.Courses.Course
            {
                Name = courseDto.Name,
                Category = courseDto.Category,
                InstructorId = instructor.Id   
            };

            return _courseRepository.Add(course);
        }


        public int UpdateCourse(CourseDto courseDto)
        {
            if (_courseRepository.Exists(courseDto.Name, courseDto.Id))
                throw new InvalidOperationException("Another course with the same name already exists.");

            var instructor = _userRepository.GetByName(courseDto.InstructorName);
            if (instructor == null)
                throw new InvalidOperationException("Instructor not found.");

            var existingCourse = _courseRepository.GetById(courseDto.Id);
            if (existingCourse == null)
                throw new KeyNotFoundException("Course not found.");

            existingCourse.Name = courseDto.Name;
            existingCourse.Category = courseDto.Category;
            existingCourse.InstructorId = instructor.Id;

            return _courseRepository.Update(existingCourse);
        }


        public bool DeleteCourse(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
                throw new KeyNotFoundException("Course not found.");

            _courseRepository.Delete(course);
            return true;
        }

    

        public CourseDto? GetByName(string name)
        {
            var c = _courseRepository.GetByName(name);
            if (c == null) return null;

            return new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Category = c.Category,
                InstructorName = c.Instructor?.Name ?? "Unknown"
            };
        }

      

        public IEnumerable<CourseDto> SearchCourses(string? name, string? category)
        {
            var courses = _courseRepository.Search(name, category);
            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                Category = c.Category,
                InstructorName = c.Instructor?.Name ?? "Unknown"
            }).ToList();
        }

     
    }
}
