﻿using CarRental.Models.Car;
using CarRental.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.Rental
{
    public class RentalModel
    {
        private CarModel car;
        private UserModel user;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Wymagane jest ID samochodu")]
        public int CarId { get; set; }
        public CarModel Car { get => car; set => car = value; }
        [Required(ErrorMessage = "Wymagane jest ID użytkownika")]
        public int UserId { get; set; }
        public UserModel User { get => user; set => user = value; }
        [Required(ErrorMessage = "Wymagana jest data rozpoczęcia wypożyczenia")]
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
