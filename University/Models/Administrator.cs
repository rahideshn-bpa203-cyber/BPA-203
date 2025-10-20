using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    internal class Administrator : Person
    {
        public string Position { get; set; }
        public string Department { get; set; }
        public int AccessLevel { get; set; }
    
    public Administrator(string firstName, string lastName, int age, string email, string id,
                             string position, string department, int accessLevel)
            : base(firstName, lastName, age, email, id)
        {
            this.Position = position;
            this.Department = department;
            this.AccessLevel = accessLevel;
        }

        public void ShowAdminInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Vəzifə: {Position}");
            Console.WriteLine($"Şöbə: {Department}");
            Console.WriteLine($"Giriş səviyyəsi: {AccessLevel}");
        }

        public void GrantAccess(Student student)
        {
            Console.WriteLine($"{student.GetFullName()} tələbəsinə sistemə giriş icazəsi verildi.");
        }
    }
}
