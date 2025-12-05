CREATE DATABASE Company;
USE Company;

CREATE TABLE Countries(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL
);

SELECT * FROM Countries;

CREATE TABLE Cities(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
);
SELECT * FROM Cities;
CREATE TABLE Employees(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    Surname VARCHAR(100) NOT NULL,
    Age INT CHECK (Age > 0),
    Salary DECIMAL(8,2) CHECK (Salary >= 0),
    Position VARCHAR(100),
    IsDeleted BIT DEFAULT 0,
    CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id)
);

INSERT INTO Countries([Name])
VALUES ('United Arab Emirates'),
       ('Turkey'),
       ('Azerbaijan');


INSERT INTO Cities([Name], CountryId)
VALUES 
    ('Dubai', 1),
    ('Istanbul', 2),
    ('Baku', 3); 

INSERT INTO Employees([Name], Surname, Age, Salary, Position, IsDeleted, CityId)
VALUES
    ('Rahide', 'Nuriyeva', 20, 3000, 'Developer', 0, 1),
    ('Aysel', 'Nuriyeva', 19, 1000, 'Tour Guide', 1, 2),
    ('Aynur', 'Guliyeva', 22, 2500, 'Designer', 0, 3),
    ('Lamiye', 'Memmedova', 19, 2000, 'Bank Officer', 0, 1),
    ('Semra', 'Memmedova', 19, 2300, 'Accountant', 0, 2),
    ('Ilahe', 'Gulizade', 25, 1800, 'Manager', 0, 3);
SELECT * FROM Countries;
SELECT * FROM Cities;
SELECT * FROM Employees;

SELECT e.Name,
       e.Surname,
       c.Name AS City,
       co.Name AS Country
FROM Employees AS e
INNER JOIN Cities AS c
    ON e.CityId = c.Id
INNER JOIN Countries AS co
    ON c.CountryId = co.Id;


SELECT e.Name,
       e.Surname,
       co.Name AS Country
FROM Employees AS e
INNER JOIN Cities AS c
    ON e.CityId = c.Id
INNER JOIN Countries AS co
    ON c.CountryId = co.Id
WHERE e.Salary > 2000;

SELECT c.Name AS City,
       co.Name AS Country
FROM Cities AS c
INNER JOIN Countries AS co
    ON c.CountryId = co.Id;

SELECT e.Name,
       e.Surname,
       e.Age,
       e.Salary,
       e.Position,
       e.IsDeleted,
       c.Name AS City,
       co.Name AS Country
FROM Employees AS e
INNER JOIN Cities AS c
    ON e.CityId = c.Id
INNER JOIN Countries AS co
    ON c.CountryId = co.Id
WHERE e.Position = 'Reseption';


SELECT e.Name,
       e.Surname,
       c.Name AS City,
       co.Name AS Country
FROM Employees AS e
INNER JOIN Cities AS c
    ON e.CityId = c.Id
INNER JOIN Countries AS co
    ON c.CountryId = co.Id
WHERE e.IsDeleted = 1;




