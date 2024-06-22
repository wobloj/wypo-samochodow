﻿using CarRental.Models.Car;
using CarRental.Models.User;

namespace CarRental.Models.Rental
{
    public class RentalViewModel
    {
        public RentalViewModel() { }

        public int Id { get; set; }
        public CarModel Car { get; set; }
        public UserModel User { get; set; }
        public DateTime RentDate { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<RentalModel> RentalsList { get; set; }
        public IEnumerable<CarModel> CarsList { get; set; }
        public IEnumerable<UserModel> UsersList { get; set; }
    }
}
