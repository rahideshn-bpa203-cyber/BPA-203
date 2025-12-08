CREATE DATABASE CompanyMM;
USE CompanyMM;

CREATE TABLE Employees(
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
    BirthDate DATE,
    Email VARCHAR(150) UNIQUE,
    CHECK (BirthDate < GETDATE())
);

CREATE TABLE Projects(
    ProjectID INT PRIMARY KEY,
    ProjectName VARCHAR(200),
    StartDate DATE,
    EndDate DATE,
    CHECK (EndDate IS NULL OR EndDate >= StartDate)
);

CREATE TABLE EmployeeProjects(
    EmployeeID INT,
    ProjectID INT,
    AssignedDate DATE,
    PRIMARY KEY(EmployeeID, ProjectID),

    FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
);

INSERT INTO Employees VALUES
(1,'Aysel','Aliyeva','1990-03-12','aysel@mail.com'),
(2,'Murad','Mammadov','1988-07-21','murad@mail.com'),
(3,'Leyla','Huseynova','1995-11-02','leyla@mail.com'),
(4,'Elvin','Quliyev','1993-01-15','elvin@mail.com'),
(5,'Nigar','Sadiqova','1989-05-30','nigar@mail.com');

INSERT INTO Projects VALUES
(1,'Web Redesign','2025-01-01','2025-04-01'),
(2,'Mobile App','2024-10-01',NULL),
(3,'ERP Migration','2024-05-01','2024-12-01');


INSERT INTO EmployeeProjects VALUES
(1,1,'2025-01-15'),
(1,2,'2025-02-01'),
(2,2,'2024-11-10'),
(3,1,'2025-03-02'),
(4,3,'2024-06-05'),
(5,1,'2025-01-20');

SELECT * FROM Employees;

SELECT * FROM Projects;

SELECT 
    e.FirstName, e.LastName,
    p.ProjectName,
    ep.AssignedDate
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID;

SELECT 
    p.ProjectName,
    COUNT(ep.EmployeeID) AS EmployeeCount
FROM Projects p
LEFT JOIN EmployeeProjects ep ON p.ProjectID = ep.ProjectID
GROUP BY p.ProjectName;

SELECT 
    e.FirstName, e.LastName,
    COUNT(ep.ProjectID) AS ProjectCount
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
GROUP BY e.FirstName, e.LastName
HAVING COUNT(ep.ProjectID) > 2;

CREATE VIEW EmployeeProjectView AS
SELECT
    e.EmployeeID,
    (e.FirstName + ' ' + e.LastName) AS FullName,
    p.ProjectID,
    p.ProjectName,
    ep.AssignedDate
FROM EmployeeProjects ep
JOIN Employees e ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID;

SELECT * FROM EmployeeProjectView
WHERE EmployeeID = 1;

CREATE PROCEDURE sp_AssignEmployeeToProject
    @emp INT,
    @proj INT
AS
BEGIN
    IF NOT EXISTS(
        SELECT * FROM EmployeeProjects
        WHERE EmployeeID = @emp AND ProjectID = @proj
    )
    BEGIN
        INSERT INTO EmployeeProjects VALUES(@emp, @proj, GETDATE());
    END
END;


CREATE FUNCTION fn_GetProjectCount(@emp INT)
RETURNS INT
AS
BEGIN
    DECLARE @c INT;
    SELECT @c = COUNT(*) 
    FROM EmployeeProjects
    WHERE EmployeeID = @emp;

    RETURN @c;
END;

SELECT dbo.fn_GetProjectCount(1);

EXEC sp_AssignEmployeeToProject 3, 2;

DELETE FROM EmployeeProjects
WHERE EmployeeID = 4;





