create database Company

use Company
create table  Employees (EmployeeID int,
FirstName nvarchar(50) ,
LastName nvarchar(50),
Email nvarchar(50),
PhoneNumber nvarchar(20),
HireDate date,
JobTitle nvarchar(50),
Salary decimal,
Department nvarchar(50))

drop table Employees

insert into Employees (EmployeeID,FirstName,LastName, Email, PhoneNumber, HireDate,JobTitle,Salary,Department)
VALUES
(1,'Vusala','Kazimova','vusu@gmail.com','+994504565668','2021-08-08','developer',2000,'it'),
(2,'Rahide','Nuruyeva','rahide@gmail.com','+994514761122','2024-07-03','sales manager',2500,'finance'),
(3,'Roya','Memmedli','roya@company.az','+994777894534','2025-11-08','designer',900,'support'),
(4,'Aysun','Bayramova','aysun@gmail.com','+994553457812','2024-12-09','hr manager',800,'sales'),
(5,'Nezrin','Abbasova','nezi@company.az.com','+994507891322','2023-09-28','developer',2200,'it')


select * from Employees;
select * from Employees where salary>2000
select * from Employees where department like 'it'
select * from Employees order by salary desc
select firstname,salary from Employees 
select * from Employees where year (hiredate)>2020
select* from Employees where email like '%company.az%'
select max(salary) As MaxEmployees from Employees
select min(salary) As MinEmployees  from Employees

SELECT AVG(salary) AS AverageAge FROM Employees;
SELECT COUNT(*) AS TotalEmployees FROM Employees;
SELECT Sum(salary) AS TotalEmployees FROM Employees;
select department ,count(*) as total from Employees group by department;
select department ,avg(salary) as aveagesalary from Employees group by department;
select department ,max(salary) as aveagesalary from Employees group by department;

UPDATE Employees
SET salary=2800
WHERE EmployeeID = 1;


UPDATE Employees
SET salary=salary*10/100+salary;

UPDATE Employees
SET jobtitle='HR Meneceri'
WHERE Firstname='Roya'and Lastname='Memmedli';

delete  from Employees where EmployeeID=5;
delete from Employees where salary<1500;

select * from Employees where firstname like '%a';
select * from Employees where salary between 2000 and 2500;

select * from Employees where department in ('finance' , 'it');