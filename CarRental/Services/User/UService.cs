using CarRental.Data;
using CarRental.Models.User;

namespace CarRental.Services.User
{
    public class UService : IUService
    {
        private readonly RentalDbContext _context;

        public UService(RentalDbContext context)
        {
            _context = context;
        }

        public List<UserModel> GetUsers()
        {
            return _context.Users.ToList();
        }

        public UserModel GetUser(int id)
        {
            var users = _context.Users.FirstOrDefault(u => u.Id == id);
            return users ?? new UserModel();
        }

        public void AddUser(string firstName, string lastName, string email, string phone)
        {
            _context.Users.Add(new UserModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            });
            _context.SaveChanges();
        }

        public void UpdateUser(int id, string firstName, string lastName, string email, string phone)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Email = email;
                user.Phone = phone;
            }
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
