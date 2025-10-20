using University.Models;

namespace University
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tələbələr
            Student s1 = new Student("Aysel", "Məmmədova", 20, "aysel@mail.com", "S001", "1001", "İnformatika", 88.5, 2);
            Student s2 = new Student("Nərgiz", "Hüseynova", 21, "nergiz@mail.com", "S002", "1002", "Riyaziyyat", 92.0, 3);
            Student s3 = new Student("Rəna", "Quliyeva", 19, "rena@mail.com", "S003", "1003", "Fizika", 68.5, 1);

            // Müəllimlər
            Teacher t1 = new Teacher("Elvin", "Əhmədov", 40, "elvin@mail.com", "T001", "İT", "C#", 800, 15);
            Teacher t2 = new Teacher("Rauf", "Səlimov", 35, "rauf@mail.com", "T002", "Riyaziyyat", "Alqoritmlər", 750, 8);

            // Administrator
            Administrator admin = new Administrator("Leyla", "Kazımova", 45, "leyla@mail.com", "A001", "Dekan", "İT", 5);

            Console.WriteLine("==== Tələbə Məlumatları ====");
            double totalScholarship = 0;
            s1.ShowStudentInfo();
            Console.WriteLine($"Təqaüd: {s1.CalculateScholarship()} AZN\n");
            totalScholarship += s1.CalculateScholarship();

            s2.ShowStudentInfo();
            Console.WriteLine($"Təqaüd: {s2.CalculateScholarship()} AZN\n");
            totalScholarship += s2.CalculateScholarship();

            s3.ShowStudentInfo();
            Console.WriteLine($"Təqaüd: {s3.CalculateScholarship()} AZN\n");
            totalScholarship += s3.CalculateScholarship();

            Console.WriteLine("==== Müəllim Məlumatları ====");
            decimal totalSalary = 0;
            t1.ShowTeacherInfo();
            Console.WriteLine($"Maaş: {t1.CalculateSalary()} AZN\n");
            totalSalary += t1.CalculateSalary();

            t2.ShowTeacherInfo();
            Console.WriteLine($"Maaş: {t2.CalculateSalary()} AZN\n");
            totalSalary += t2.CalculateSalary();

            Console.WriteLine("==== Administrator ====");
            admin.ShowAdminInfo();
            admin.GrantAccess(s2);

            Console.WriteLine("\n==== Statistika ====");
            Console.WriteLine($"Ümumi təqaüd xərci: {totalScholarship} AZN");
            Console.WriteLine($"Ümumi maaş xərci: {totalSalary} AZN");

            Console.ReadLine();
        }
    }
}

