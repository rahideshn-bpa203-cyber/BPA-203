using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Models
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }


        public Person(string firstName, string lastName, int age, string email, string id)
        {
            this.FirstName=firstName;
            this.LastName=lastName;
            this.Age=age;
            this.Email=email;
            this.Id=id;

        }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
            
        }
        public void ShowBasicInfo()
        {
            Console.WriteLine($"Ad Soyad:{GetFullName()}");
            Console.WriteLine($"Yas:{Age}");
            Console.WriteLine($"Email:{Email}");
            Console.WriteLine($"ID:{Id}");
        }


    }


}
