using Microsoft.AspNetCore.Mvc;
using Training_Management_System.PLL.DTOS;
using Training_Management_System.PLL.Services.SessionService;
using Training_Management_Sysytem.PL.Models.Courses;

namespace Training_Management_Sysytem.PL.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        #region index
        [HttpGet] 
        public IActionResult Index()
        {
            var session = _sessionService.GetAllWithCourseName();
            return View(session);
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
        public IActionResult Create(SessionDto session)
        {
            if (!ModelState.IsValid)
                return View(session);

            try
            {
                var error = _sessionService.Create(session);

                if (error != null) 
                {
                    ModelState.AddModelError(string.Empty, error);
                    return View(session);
                }

                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error: " + ex.Message);
                return View(session);
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
            var session = _sessionService.GetById(id.Value);
            if (session is null)
            {
                return NotFound();
            }
            return View(new SessionEditViewModel()
            {
               CourseId=session.CourseId,
               StartDate =session.StartDate,
               EndDate = session.EndDate,
            }); 
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Edit(SessionEditViewModel sessionVM)
        {
            if (!ModelState.IsValid)
                return View(sessionVM);

            try
            {
                var updatedsession = new SessionDto
                {
                    Id = sessionVM.Id,
                    CourseId = sessionVM.CourseId,
                    StartDate = sessionVM.StartDate,
                    EndDate = sessionVM.EndDate
                };

                var error = _sessionService.Update(updatedsession); 

                if (error != null) 
                {
                    ModelState.AddModelError(string.Empty, error);
                    return View(sessionVM);
                }

                return RedirectToAction(nameof(Index)); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error: " + ex.Message);
                return View(sessionVM);
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
            var session = _sessionService.GetById(id.Value);
            if (session is null)
            {
                return NotFound();
            }
            return View(session);

        }

        #endregion
        #region Post
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var error = _sessionService.Delete(id); 
                if (error != null) 
                {
                    ModelState.AddModelError(string.Empty, error);
                    return RedirectToAction(nameof(Index));
                }

               
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
        public IActionResult Search(string? name)
        {
            var sessions = _sessionService.SearchWithCourseName(name);
            return View("Index", sessions);
        }
        #endregion
    }
}
