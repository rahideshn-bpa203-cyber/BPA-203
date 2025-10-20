using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    internal class Student : Person
    {
        public string StudentNumber { get; set; }
        public string Faculty { get; set; }
        public double GPA { get; set; }
        public int Year { get; set; }

        public Student(string firstName, string lastName, int age, string email, string id, string studentNumber, string faculty, double gPA, int year)
            : base(firstName, lastName, age, email, id)
        {
            this.StudentNumber = studentNumber;
            this.Faculty = faculty;
            this.GPA = gPA;
            this.Year = year;
        }
        public void ShowStudentInfo()
        {
            Console.WriteLine($"Telebe nomresi:{StudentNumber}");
            Console.WriteLine($"Fakulte:{Faculty}");
            Console.WriteLine($"GPA:{GPA}");
            Console.WriteLine($"Kurs:{Year}");

        }
        public double CalculateScholarship()
        {
            if (GPA >= 90) return 500;
            else if (GPA >= 80) return 450;
            else if (GPA >= 70) return 200;
            else return 0;
        }

    }
}


