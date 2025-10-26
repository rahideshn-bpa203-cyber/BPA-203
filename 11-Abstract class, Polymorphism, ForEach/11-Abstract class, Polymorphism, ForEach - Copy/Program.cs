using _11_Abstract_class__Polymorphism__ForEach.Models;
using System.ComponentModel.DataAnnotations;

namespace _11_Abstract_class__Polymorphism__ForEach
{
    internal class Program
    {
        static void Main()
        {
            
            Car car1 = new("Mercedes", "E200", 2023, "90-CAR-001", 4, 500, true, 220);
            Car car2 = new("BMW", "320i", 2022, "90-CAR-002", 4, 480, true, 235);
            Car car3 = new("Toyota", "Camry", 2021, "90-CAR-003", 4, 524, true, 210); 
           

            #region 4.Car ucun 500
            Console.WriteLine("Cars");

            car1.ShowCarInfo();
            Console.WriteLine($"500 km ucun yanacaq xerci {car1.CalculateFuelCost(500)} AZN");
            car2.ShowCarInfo();
            Console.WriteLine($"500 km ucun yanacaq xerci {car2.CalculateFuelCost(500)} AZN");
            car3.ShowCarInfo();
            Console.WriteLine($"500 km ucun yanacaq xerci {car3.CalculateFuelCost(500)} AZN");

            #endregion


            Motorcycle moto1 = new ("Yamaha", "R1", 2023, "90-MOTO-001", 998, false, 299, "Sport");
            Motorcycle moto2 = new ("Harley-Davidson", "Softail", 2022, "90-MOTO-002", 1986, true, 180, "Cruiser");
            #region 4.Moto ucun 300
            Console.WriteLine("Motorcycle");
            moto1.ShowMotorcycleInfo();
            Console.WriteLine($"300 km ucun yanacaq xerci {moto1.CalculateFuelCost(300)} AZN");
            moto2.ShowMotorcycleInfo();
            Console.WriteLine($"300 km ucun yanacaq xerci {car1.CalculateFuelCost(300)} AZN"); 
            #endregion

            Truck truck1 = new("MAN", "TGX", 2020, "90-TRK-001", 18, 3, 120);
            Truck truck2 = new("Volvo", "FH16", 2021, "90-TRK-002", 25, 4, 110);
            #region 4.Truck ucun 800
            Console.WriteLine("Truck");

            truck1.ShowTruckInfo();
            Console.WriteLine($"800 km ucun yanacaq xerci:{truck1.CalculateFuelCost(800)} AZN");
            truck2.ShowTruckInfo();
            Console.WriteLine($"800 km ucun yanacaq xerci:{truck2.CalculateFuelCost(800)} AZN");

            #endregion

            #region 5.Truck-a 5 ton elave yukleyende yeni xerci
            Console.WriteLine("Yuk elave etmek");
            truck1.LoadCargo(5);
            Console.WriteLine($"Yeni yanacaq xerci {truck1.CalculateFuelCost}AZN");
            #endregion

            #region 6.1 Umumi neqliyyat sayi
            Vehicle[] vehicles = { car1, car2, car3, moto1, moto2, truck1, truck2 };
            Console.WriteLine("umumi neqliyyat sayu{ vehicles.Length}");
            #endregion

            #region 6.2 Orta maksimum suret(butun neqliyyatlar ucun)
            foreach (var vehicle in vehicles) { }
            #endregion
            #region 6.3 En bahali yanacaq xerci olan neqliyyat
            foreach (var vehicle in vehicles) { }   
            #endregion




        }
    }
}
