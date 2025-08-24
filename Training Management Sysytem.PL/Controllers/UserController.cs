using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Training_Management_System.PLL.DTOS;
using Training_Management_System.PLL.Services.UserService;
using Training_Management_Sysytem.PL.Models.Courses;

namespace Training_Management_Sysytem.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #region Index
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
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

        public IActionResult Create(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return View(userDto);

            string? error = _userService.Create(userDto);

            if (error != null)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(userDto);
            }

            return RedirectToAction("Index");
        }
    


    #endregion

    #endregion
    #region Update
       #region Get
        // Course/Edit/id?
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var user = _userService.GetById(id.Value);
            if (user is null)
            {
                return NotFound();
            }
            return View(new UserEditViewModel()
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
            });
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Edit(UserEditViewModel userVM)
        {
            if (!ModelState.IsValid)
                return View(userVM);

            var message = string.Empty;
            try
            {
                var updateduser = new UserDto
                {
                    Id = userVM.Id,
                    Name = userVM.Name,
                    Email = userVM.Email,
                    Role = userVM.Role,
                };

                var updated = _userService.Update(updateduser) > 0;

                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }

                message = "Sorry, An Error Occurred While Updating The user";
                ModelState.AddModelError(string.Empty, message);
                return View(userVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error: " + ex.Message);
                return View(userVM);
            }
        }


        #endregion
        #endregion
        #region delete
        #region Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var user = _userService.GetById(id.Value);
            if (user is null)
            {
                return NotFound();
            }
            return View(user);

        }

        #endregion
        #region Post
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var message = string.Empty;
                var deleted = _userService.Delete(id);
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
    }
}
