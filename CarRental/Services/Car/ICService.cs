using CarRental.Models.Car;

namespace CarRental.Services.Car
{
    public interface ICService
    {
        public List<CarModel> GetCars();
        public CarModel GetCar(int id);
        public void AddCar(string car, string model, string engine, string bodyType, int productionYear);
        public void DeleteCar(int id);
        public void UpdateCar(int id, string car, string model, string engine, string bodyType, int productionYear);
    }
}
