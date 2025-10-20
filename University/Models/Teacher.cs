using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    internal class Teacher : Person
    {
        public string Department { get; set; }
        public string MainSubject { get; set; }
        public decimal BaseSalary { get; set; }

        public int ExperienceYears { get; set; }

        public Teacher(string firstName, string lastName, int age, string email, string id, string department , string mainSubject, decimal baseSalary, int experienceYears)
           : base(firstName, lastName, age, email, id)
        {
            this.Department = department;
            this.MainSubject = mainSubject;
            this.BaseSalary = baseSalary;
            this.ExperienceYears = experienceYears;
        }







        public void ShowTeacherInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Kafedra:{Department}");
            Console.WriteLine($"Esas fenn:{MainSubject}");
            Console.WriteLine($"Baza maas:{BaseSalary} AZN");
            Console.WriteLine($"Tecrube:{ExperienceYears}il");
        }
        public decimal CalculateSalary()
        {
            return BaseSalary + (ExperienceYears * 50);
        }


    }

 }














       

    
