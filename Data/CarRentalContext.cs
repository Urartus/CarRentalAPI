using Microsoft.EntityFrameworkCore;
using CarRentalAPI.Models;
using System;

namespace CarRentalAPI.Data
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { CarID = 1, Make = "BMW", Model = "M3", Year = 2023, PricePerMinute = 35.00m, IsAvailable = true },
                new Car { CarID = 2, Make = "Mercedes", Model = "C-Class", Year = 2018, PricePerMinute = 30.00m, IsAvailable = true },
                new Car { CarID = 3, Make = "Audi", Model = "A4", Year = 2017, PricePerMinute = 28.00m, IsAvailable = true },
                new Car { CarID = 4, Make = "Chevrolet", Model = "Camaro", Year = 2022, PricePerMinute = 25.00m, IsAvailable = true },
                new Car { CarID = 5, Make = "Lexus", Model = "IS", Year = 2021, PricePerMinute = 22.00m, IsAvailable = true },
                new Car { CarID = 6, Make = "Ford", Model = "Mustang", Year = 2021, PricePerMinute = 20.00m, IsAvailable = false },
                new Car { CarID = 7, Make = "Honda", Model = "Civic", Year = 2019, PricePerMinute = 18.00m, IsAvailable = true },
                new Car { CarID = 8, Make = "Toyota", Model = "Corolla", Year = 2020, PricePerMinute = 15.00m, IsAvailable = true },
                new Car { CarID = 9, Make = "Volkswagen", Model = "Golf", Year = 2020, PricePerMinute = 14.00m, IsAvailable = true },
                new Car { CarID = 10, Make = "Nissan", Model = "Altima", Year = 2019, PricePerMinute = 12.00m, IsAvailable = true }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { ClientID = 1, FirstName = "Иван", LastName = "Петров", PhoneNumber = "89123456789", Email = "ivan.petrov@example.com" },
                new Client { ClientID = 2, FirstName = "Анна", LastName = "Сидорова", PhoneNumber = "89234567890", Email = "anna.sidorova@example.com" },
                new Client { ClientID = 3, FirstName = "Петр", LastName = "Иванов", PhoneNumber = "89345678901", Email = "petr.ivanov@example.com" },
                new Client { ClientID = 4, FirstName = "Мария", LastName = "Кузнецова", PhoneNumber = "89456789012", Email = "maria.kuznevova@example.com" },
                new Client { ClientID = 5, FirstName = "Сергей", LastName = "Смирнов", PhoneNumber = "89567890123", Email = "sergey.smirnov@example.com" },
                new Client { ClientID = 6, FirstName = "Елена", LastName = "Васильева", PhoneNumber = "89678901234", Email = "elena.vasilieva@example.com" },
                new Client { ClientID = 7, FirstName = "Дмитрий", LastName = "Медведев", PhoneNumber = "89789012345", Email = "dmitriy.medvedev@example.com" },
                new Client { ClientID = 8, FirstName = "Ольга", LastName = "Тарасова", PhoneNumber = "89890123456", Email = "olga.tarasova@example.com" },
                new Client { ClientID = 9, FirstName = "Алексей", LastName = "Соколов", PhoneNumber = "89901234567", Email = "aleksey.sokolov@example.com" },
                new Client { ClientID = 10, FirstName = "Наталья", LastName = "Попова", PhoneNumber = "89012345678", Email = "natalya.popova@example.com" },
                new Client { ClientID = 11, FirstName = "Виктор", LastName = "Новиков", PhoneNumber = "89112345678", Email = "viktor.novikov@example.com" },
                new Client { ClientID = 12, FirstName = "Татьяна", LastName = "Алексеева", PhoneNumber = "89212345678", Email = "tatyana.alekseeva@example.com" },
                new Client { ClientID = 13, FirstName = "Андрей", LastName = "Лебедев", PhoneNumber = "89312345678", Email = "andrey.lebedev@example.com" },
                new Client { ClientID = 14, FirstName = "Ирина", LastName = "Кузнецова", PhoneNumber = "89412345678", Email = "irina.kuznevova@example.com" },
                new Client { ClientID = 15, FirstName = "Сергей", LastName = "Соколов", PhoneNumber = "89512345678", Email = "sergey.sokolov@example.com" }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental { RentalID = 1, CarID = 1, ClientID = 15, RentalDate = new DateTime(2024, 4, 1, 10, 0, 0), ReturnDate = new DateTime(2024, 4, 1, 12, 30, 0), TotalCost = 1225.00m, DurationInMinutes = 35 },
                new Rental { RentalID = 2, CarID = 5, ClientID = 3, RentalDate = new DateTime(2024, 4, 2, 11, 0, 0), ReturnDate = new DateTime(2024, 4, 2, 13, 0, 0), TotalCost = 600.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 3, CarID = 7, ClientID = 8, RentalDate = new DateTime(2024, 4, 3, 9, 30, 0), ReturnDate = new DateTime(2024, 4, 3, 11, 0, 0), TotalCost = 560.00m, DurationInMinutes = 90 },
                new Rental { RentalID = 4, CarID = 2, ClientID = 10, RentalDate = new DateTime(2024, 4, 4, 14, 0, 0), ReturnDate = new DateTime(2024, 4, 4, 16, 0, 0), TotalCost = 500.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 5, CarID = 10, ClientID = 1, RentalDate = new DateTime(2024, 4, 5, 10, 15, 0), ReturnDate = new DateTime(2024, 4, 5, 12, 15, 0), TotalCost = 440.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 6, CarID = 6, ClientID = 12, RentalDate = new DateTime(2024, 4, 6, 12, 0, 0), ReturnDate = new DateTime(2024, 4, 6, 14, 0, 0), TotalCost = 400.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 7, CarID = 3, ClientID = 7, RentalDate = new DateTime(2024, 4, 7, 9, 0, 0), ReturnDate = new DateTime(2024, 4, 7, 11, 30, 0), TotalCost = 315.00m, DurationInMinutes = 150 },
                new Rental { RentalID = 8, CarID = 8, ClientID = 5, RentalDate = new DateTime(2024, 4, 8, 11, 15, 0), ReturnDate = new DateTime(2024, 4, 8, 13, 15, 0), TotalCost = 300.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 9, CarID = 9, ClientID = 2, RentalDate = new DateTime(2024, 4, 9, 10, 0, 0), ReturnDate = new DateTime(2024, 4, 9, 12, 0, 0), TotalCost = 280.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 10, CarID = 4, ClientID = 13, RentalDate = new DateTime(2024, 4, 10, 12, 30, 0), ReturnDate = new DateTime(2024, 4, 10, 14, 30, 0), TotalCost = 210.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 11, CarID = 1, ClientID = 11, RentalDate = new DateTime(2024, 4, 11, 9, 45, 0), ReturnDate = new DateTime(2024, 4, 11, 11, 45, 0), TotalCost = 1225.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 12, CarID = 2, ClientID = 12, RentalDate = new DateTime(2024, 4, 12, 10, 30, 0), ReturnDate = new DateTime(2024, 4, 12, 12, 30, 0), TotalCost = 600.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 13, CarID = 3, ClientID = 13, RentalDate = new DateTime(2024, 4, 13, 11, 0, 0), ReturnDate = new DateTime(2024, 4, 13, 13, 0, 0), TotalCost = 560.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 14, CarID = 4, ClientID = 14, RentalDate = new DateTime(2024, 4, 14, 9, 15, 0), ReturnDate = new DateTime(2024, 4, 14, 11, 15, 0), TotalCost = 500.00m, DurationInMinutes = 120 },
                new Rental { RentalID = 15, CarID = 5, ClientID = 15, RentalDate = new DateTime(2024, 4, 15, 12, 0, 0), ReturnDate = new DateTime(2024, 4, 15, 14, 0, 0), TotalCost = 440.00m, DurationInMinutes = 120 }
            );
        }
    }
}