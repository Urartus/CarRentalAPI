using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PricePerMinute = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarID", "IsAvailable", "Make", "Model", "PricePerMinute", "Year" },
                values: new object[,]
                {
                    { 1, true, "BMW", "M3", 35.00m, 2023 },
                    { 2, true, "Mercedes", "C-Class", 30.00m, 2018 },
                    { 3, true, "Audi", "A4", 28.00m, 2017 },
                    { 4, true, "Chevrolet", "Camaro", 25.00m, 2022 },
                    { 5, true, "Lexus", "IS", 22.00m, 2021 },
                    { 6, false, "Ford", "Mustang", 20.00m, 2021 },
                    { 7, true, "Honda", "Civic", 18.00m, 2019 },
                    { 8, true, "Toyota", "Corolla", 15.00m, 2020 },
                    { 9, true, "Volkswagen", "Golf", 14.00m, 2020 },
                    { 10, true, "Nissan", "Altima", 12.00m, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ivan.petrov@example.com", "Иван", "Петров", "89123456789" },
                    { 2, "anna.sidorova@example.com", "Анна", "Сидорова", "89234567890" },
                    { 3, "petr.ivanov@example.com", "Петр", "Иванов", "89345678901" },
                    { 4, "maria.kuznevova@example.com", "Мария", "Кузнецова", "89456789012" },
                    { 5, "sergey.smirnov@example.com", "Сергей", "Смирнов", "89567890123" },
                    { 6, "elena.vasilieva@example.com", "Елена", "Васильева", "89678901234" },
                    { 7, "dmitriy.medvedev@example.com", "Дмитрий", "Медведев", "89789012345" },
                    { 8, "olga.tarasova@example.com", "Ольга", "Тарасова", "89890123456" },
                    { 9, "aleksey.sokolov@example.com", "Алексей", "Соколов", "89901234567" },
                    { 10, "natalya.popova@example.com", "Наталья", "Попова", "89012345678" },
                    { 11, "viktor.novikov@example.com", "Виктор", "Новиков", "89112345678" },
                    { 12, "tatyana.alekseeva@example.com", "Татьяна", "Алексеева", "89212345678" },
                    { 13, "andrey.lebedev@example.com", "Андрей", "Лебедев", "89312345678" },
                    { 14, "irina.kuznevova@example.com", "Ирина", "Кузнецова", "89412345678" },
                    { 15, "sergey.sokolov@example.com", "Сергей", "Соколов", "89512345678" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "RentalID", "CarID", "ClientID", "DurationInMinutes", "RentalDate", "ReturnDate", "TotalCost" },
                values: new object[,]
                {
                    { 1, 1, 15, 35, new DateTime(2024, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), 1225.00m },
                    { 2, 5, 3, 120, new DateTime(2024, 4, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), 600.00m },
                    { 3, 7, 8, 90, new DateTime(2024, 4, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), 560.00m },
                    { 4, 2, 10, 120, new DateTime(2024, 4, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), 500.00m },
                    { 5, 10, 1, 120, new DateTime(2024, 4, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 12, 15, 0, 0, DateTimeKind.Unspecified), 440.00m },
                    { 6, 6, 12, 120, new DateTime(2024, 4, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), 400.00m },
                    { 7, 3, 7, 150, new DateTime(2024, 4, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), 315.00m },
                    { 8, 8, 5, 120, new DateTime(2024, 4, 8, 11, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 8, 13, 15, 0, 0, DateTimeKind.Unspecified), 300.00m },
                    { 9, 9, 2, 120, new DateTime(2024, 4, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), 280.00m },
                    { 10, 4, 13, 120, new DateTime(2024, 4, 10, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 10, 14, 30, 0, 0, DateTimeKind.Unspecified), 210.00m },
                    { 11, 1, 11, 120, new DateTime(2024, 4, 11, 9, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), 1225.00m },
                    { 12, 2, 12, 120, new DateTime(2024, 4, 12, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 12, 30, 0, 0, DateTimeKind.Unspecified), 600.00m },
                    { 13, 3, 13, 120, new DateTime(2024, 4, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), 560.00m },
                    { 14, 4, 14, 120, new DateTime(2024, 4, 14, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 14, 11, 15, 0, 0, DateTimeKind.Unspecified), 500.00m },
                    { 15, 5, 15, 120, new DateTime(2024, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 440.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarID",
                table: "Rentals",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_ClientID",
                table: "Rentals",
                column: "ClientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
