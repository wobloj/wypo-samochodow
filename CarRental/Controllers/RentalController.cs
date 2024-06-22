using CarRental.Models.Rental;
using CarRental.Services.Car;
using CarRental.Services.Rental;
using CarRental.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace RentalService.Controllers
{
    public class RentalController : Controller
    {
        private readonly ILogger<RentalController> _logger;
        private readonly IRService _rentalService;
        private readonly ICService _carService;
        private readonly IUService _userService;

        public RentalController(ILogger<RentalController> logger, IRService rentalService, ICService carService, IUService userService)
        {
            _logger = logger;
            _rentalService = rentalService;
            _carService = carService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new RentalViewModel()
            {
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };
            return View(model);
        }

        public IActionResult AddRent()
        {
            var model = new RentalViewModel()
            {
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult AddRent(int carId, int userId)
        {
            var model = new RentalViewModel()
            {
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };

            if (ModelState.IsValid)
            {
                _rentalService.AddRental(carId, userId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult ChangeReturnState(int id, bool isReturned)
        {
            _rentalService.ChangeReturnState(id, isReturned);
            return RedirectToAction("Index");
        }

        public IActionResult EditRent(int id, int carId, int userId, DateTime rentDate)
        {
            var model = new RentalViewModel()
            {
                Id = id,
                CarId = carId,
                UserId = userId,
                RentDate = rentDate,
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditThisRent(int id, int carId, int userId, DateTime rentDate)
        {
            var model = new RentalViewModel()
            {
                Id = id,
                CarId = carId,
                UserId = userId,
                RentDate = rentDate,
                RentalsList = _rentalService.GetRentals(),
                CarsList = _carService.GetCars(),
                UsersList = _userService.GetUsers(),
            };

            if (ModelState.IsValid)
            {
                _rentalService.EditRental(id, carId, userId, rentDate);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
