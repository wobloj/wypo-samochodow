using Microsoft.AspNetCore.Mvc;
using CarRental.Models.User;
using CarRental.Services.User;

namespace CarRental.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUService _userService;

        public UserController(ILogger<UserController> logger, IUService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new UserViewModel()
            {
                Users = _userService.GetUsers()
            };
            return View(model);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(string firstName, string lastName, string email, string phone)
        {
            if (ModelState.IsValid)
            {
                _userService.AddUser(firstName, lastName, email, phone);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditUser(int id, string firstName, string lastName, string email, string phone)
        {
            var model = new EditUserViewModel()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditThisUser(int id, string firstName, string lastName, string email, string phone)
        {
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(id, firstName, lastName, email, phone);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult RemoveUser(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
