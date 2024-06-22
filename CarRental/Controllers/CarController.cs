using Microsoft.AspNetCore.Mvc;
using CarRental.Models.Car;
using CarRental.Services.Car;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        public readonly ILogger<CarController> _logger;
        private readonly ICService _carService;

        public CarController(ILogger<CarController> logger, ICService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var model = new CarViewModel()
            {
                Cars = _carService.GetCars(),
            };
            return View(model);
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(string car, string model, string engine, string bodyType, int productionYear)
        {
            if (ModelState.IsValid)
            {
                _carService.AddCar(car, model, engine, bodyType, productionYear);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditCar(string car, string model, string engine, string bodyType, int productionYear)
        {
            var carModel = new EditCarViewModel()
            {
                Car = car,
                Model = model,
                Engine = engine,
                BodyType = bodyType,
                ProductionYear = productionYear,
            };

            return View(carModel);
        }

        [HttpPost]
        public IActionResult EditThisCar(int id, string car, string model, string engine, string bodyType, int productionYear)
        {
            if (ModelState.IsValid)
            {
                _carService.UpdateCar(id, car, model, engine, bodyType, productionYear);
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult RemoveCar(int Id)
        {
            _carService.DeleteCar(Id);
            return RedirectToAction("Index");
        }
    }
}
