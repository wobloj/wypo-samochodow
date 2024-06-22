using CarRental.Data;
using CarRental.Models.Car;

namespace CarRental.Services.Car
{
    public class CService : ICService
    {
        private readonly RentalDbContext _context;

        public CService(RentalDbContext context)
        {
            _context = context;
        }

        public List<CarModel> GetCars()
        {
            return _context.Cars.ToList();
        }

        public CarModel GetCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            return car ?? new CarModel();
        }

        public void AddCar(string car, string model, string engine, string bodyType, int productionYear)
        {
            _context.Add(new CarModel
            {
                Car = car,
                Model = model,
                Engine = engine,
                BodyType = bodyType,
                ProductionYear = productionYear
            });
            _context.SaveChanges();
        }

        public void UpdateCar(int id, string car, string model, string engine, string bodyType, int productionYear)
        {
            var carId = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (carId != null)
            {
                carId.Car = car;
                carId.Model = model;
                carId.Engine = engine;
                carId.BodyType = bodyType;
                carId.ProductionYear = productionYear;
            }
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.FirstOrDefault(car => car.Id == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}
