using CarRental.Models.Rental;

namespace CarRental.Services.Rental
{
    public interface IRService
    {
        public List<RentalModel> GetRentals();
        public RentalModel GetRental(int id);
        public void AddRental(int carId, int userId);
        public void EditRental(int id, int carId, int userId, DateTime RentDate);
        public void DeleteRental(int id);
        public void ChangeReturnState(int id, bool isReturned);
    }
}
