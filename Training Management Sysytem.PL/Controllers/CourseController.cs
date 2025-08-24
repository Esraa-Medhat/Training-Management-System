using Microsoft.AspNetCore.Mvc;
using Training_Management_System.DAL.Models.Courses;
using Training_Management_System.DAL.Presistance.Data.Migrations;
using Training_Management_System.PLL.DTOS;
using Training_Management_System.PLL.Services.Course;
using Training_Management_Sysytem.PL.Models.Courses;

namespace Training_Management_Sysytem.PL.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;


        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;

        }
        #region index
        [HttpGet] //Course/Index
        public IActionResult Index()
        {
            var Course = _courseService.GetAll();
            return View(Course);
        }
        #endregion
        #region Create
        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Create(CourseDto course)
        {
            if (!ModelState.IsValid)
                return View(course);

            try
            {
                var result = _courseService.CreateCourse(course);

                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Sorry The Course Has Not Been Created");
                    return View(course);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error: " + ex.Message);
                return View(course);
            }
        }

        #endregion
        #endregion
        #region Edit 
        #region Get
        // Course/Edit/id?
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var course = _courseService.GetCourseById(id.Value);
            if (course is null)
            {
                return NotFound();
            }
            return View(new CourseEditViewModel()
            {
                Name = course.Name,
                Category = course.Category,
                InstructorName = course.InstructorName,
            });
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Edit(CourseEditViewModel courseVM)
        {
            if (!ModelState.IsValid)
                return View(courseVM);

            var message = string.Empty;
            try
            {
                var updatedcourse = new CourseDto
                {
                    Id = courseVM.Id,
                    Name = courseVM.Name,
                    Category = courseVM.Category,
                    InstructorName = courseVM.InstructorName,
                };

                var updated = _courseService.UpdateCourse(updatedcourse) > 0;

                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }

                message = "Sorry, An Error Occurred While Updating The Course";
                ModelState.AddModelError(string.Empty, message);
                return View(courseVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error: " + ex.Message);
                return View(courseVM);
            }
        }


        #endregion
        #endregion
        #region Delete
        #region Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var course = _courseService.GetCourseById(id.Value);
            if (course is null)
            {
                return NotFound();
            }
            return View(course);

        }

        #endregion
        #region Post
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var message = string.Empty;
                var deleted = _courseService.DeleteCourse(id);
                if (deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Sorry, An Error Occurred During Deleting The Course");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error: " + ex.Message);
                return RedirectToAction(nameof(Index));

            }
        }
        #endregion
        #endregion
        #region Search
        [HttpGet]
        public IActionResult Search(string? name, string? category)
        {
            var courses = _courseService.SearchCourses(name, category);
            return View("Index",courses);
        }
        #endregion

    }
}
