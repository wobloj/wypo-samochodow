using CarRental.Models.Car;
using CarRental.Models.Rental;
using CarRental.Models.User;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options)
        {
        }

        public DbSet<RentalModel> Rentals { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CarModel> Cars { get; set; }
    }
}
