USE CarRentalSystem;

-- Создание таблицы Cars
CREATE TABLE Cars (
    CarID INT PRIMARY KEY IDENTITY(1,1),
    Make NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    PricePerMinute DECIMAL(18,2) NOT NULL,
    IsAvailable BIT DEFAULT 1
);

-- Создание таблицы Clients
CREATE TABLE Clients (
    ClientID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100)
);

-- Создание таблицы Rentals
CREATE TABLE Rentals (
    RentalID INT PRIMARY KEY IDENTITY(1,1),
    CarID INT NOT NULL,
    ClientID INT NOT NULL,
    RentalDate DATETIME NOT NULL,
    ReturnDate DATETIME,
    TotalCost DECIMAL(18,2) NOT NULL,
    DurationInMinutes INT,

    FOREIGN KEY (CarID) REFERENCES Cars(CarID),
    FOREIGN KEY (ClientID) REFERENCES Clients(ClientID)
);

-- Добавление 10 автомобилей с различными ценами в минуту
INSERT INTO Cars (Make, Model, Year, PricePerMinute, IsAvailable)
VALUES 
(N'BMW', N'M3', 2023, 35.00, 1),          -- Самая дорогая машина
(N'Mercedes', N'C-Class', 2018, 30.00, 1), -- Меньше BMW M3
(N'Audi', N'A4', 2017, 28.00, 1),          -- Меньше Mercedes C-Class
(N'Chevrolet', N'Camaro', 2022, 25.00, 1), -- Меньше Audi A4
(N'Lexus', N'IS', 2021, 22.00, 1),         -- Меньше Chevrolet Camaro
(N'Ford', N'Mustang', 2021, 20.00, 0),     -- Меньше Lexus IS
(N'Honda', N'Civic', 2019, 18.00, 1),       -- Меньше Ford Mustang
(N'Toyota', N'Corolla', 2020, 15.00, 1),    -- Меньше Honda Civic
(N'Volkswagen', N'Golf', 2020, 14.00, 1),   -- Меньше Toyota Corolla
(N'Nissan', N'Altima', 2019, 12.00, 1);     -- Самая дешёвая машина

-- Добавление 15 клиентов
INSERT INTO Clients (FirstName, LastName, PhoneNumber, Email)
VALUES 
(N'Иван', N'Петров', N'89123456789', N'ivan.petrov@example.com'),
(N'Анна', N'Сидорова', N'89234567890', N'anna.sidorova@example.com'),
(N'Петр', N'Иванов', N'89345678901', N'petr.ivanov@example.com'),
(N'Мария', N'Кузнецова', N'89456789012', N'maria.kuznevova@example.com'),
(N'Сергей', N'Смирнов', N'89567890123', N'sergey.smirnov@example.com'),
(N'Елена', N'Васильева', N'89678901234', N'elena.vasilieva@example.com'),
(N'Дмитрий', N'Медведев', N'89789012345', N'dmitriy.medvedev@example.com'),
(N'Ольга', N'Тарасова', N'89890123456', N'olga.tarasova@example.com'),
(N'Алексей', N'Соколов', N'89901234567', N'aleksey.sokolov@example.com'),
(N'Наталья', N'Попова', N'89012345678', N'natalya.popova@example.com'),
(N'Виктор', N'Новиков', N'89112345678', N'viktor.novikov@example.com'),
(N'Татьяна', N'Алексеева', N'89212345678', N'tatyana.alekseeva@example.com'),
(N'Андрей', N'Лебедев', N'89312345678', N'andrey.lebedev@example.com'),
(N'Ирина', N'Кузнецова', N'89412345678', N'irina.kuznevova@example.com'),
(N'Сергей', N'Соколов', N'89512345678', N'sergey.sokolov@example.com');

-- Добавление примеров аренд с поминутной оплатой
INSERT INTO Rentals (CarID, ClientID, RentalDate, ReturnDate, TotalCost, DurationInMinutes)
VALUES 
(1, 1, '2024-04-01 10:00:00', '2024-04-01 12:30:00', 1225.00, 35),
(2, 2, '2024-04-02 11:00:00', '2024-04-02 13:00:00', 600.00, 20),
(3, 3, '2024-04-03 09:30:00', '2024-04-03 11:00:00', 560.00, 20),
(4, 4, '2024-04-04 14:00:00', '2024-04-04 16:00:00', 500.00, 20),
(5, 5, '2024-04-05 10:15:00', '2024-04-05 12:15:00', 440.00, 20),
(6, 6, '2024-04-06 12:00:00', '2024-04-06 14:00:00', 400.00, 20),
(7, 7, '2024-04-07 09:00:00', '2024-04-07 11:30:00', 315.00, 21),
(8, 8, '2024-04-08 11:15:00', '2024-04-08 13:15:00', 300.00, 20),
(9, 9, '2024-04-09 10:00:00', '2024-04-09 12:00:00', 280.00, 20),
(10, 10, '2024-04-10 12:30:00', '2024-04-10 14:30:00', 210.00, 21),
(1, 11, '2024-04-11 09:45:00', '2024-04-11 11:45:00', 1225.00, 35),
(2, 12, '2024-04-12 10:30:00', '2024-04-12 12:30:00', 600.00, 20),
(3, 13, '2024-04-13 11:00:00', '2024-04-13 13:00:00', 560.00, 20),
(4, 14, '2024-04-14 09:15:00', '2024-04-14 11:15:00', 500.00, 20),
(5, 15, '2024-04-15 12:00:00', '2024-04-15 14:00:00', 440.00, 20);