using Microsoft.AspNetCore.Mvc;
using Training_Management_System.DAL.Models.Courses;
using Training_Management_System.PLL.DTOS;
using Training_Management_System.PLL.Services.GradeService;
using Training_Management_Sysytem.PL.Models.Courses;
using Training_Management_Sysytem.PL.Models.Edit;

namespace Training_Management_Sysytem.PL.Controllers
{
   
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        #region index
        [HttpGet]
        public IActionResult Index()
        {
            var grade = _gradeService.GetAll();
            return View(grade);
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
        public IActionResult Create(GradeDto grade)
        {
            if (!ModelState.IsValid)
                return View(grade);

            try
            {
                var result = _gradeService.Create(grade);

                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Sorry The Course Has Not Been Created");
                    return View(grade);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error: " + ex.Message);
                return View(grade);
            }
        }

        #endregion
        #endregion
      









    }
}