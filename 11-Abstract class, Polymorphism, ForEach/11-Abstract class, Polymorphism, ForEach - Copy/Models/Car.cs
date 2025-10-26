using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _11_Abstract_class__Polymorphism__ForEach.Models
{
    internal class Car :Vehicle
    {
        public int DoorsCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string brand, string model, int year, string plateNumber,int doorsCount,int trunkCapacity,bool isAutomatic,int maxSpeed) 
            :base(brand, model, year, plateNumber)
        {
            this.DoorsCount = doorsCount;
            this.TrunkCapacity = trunkCapacity;
            this. IsAutomatic= isAutomatic;
            this.MaxSpeed = maxSpeed;
        
        }

        public override string GetVehicleInfo()
        {
            return $"Brand:{Brand},Model:{Model},Year:{Year},PlateNumber:{PlateNumber} FuelLevel{FuelLevel},DoorsCount:{DoorsCount},TrunkCapacity:{TrunkCapacity},IsAutomatic:{IsAutomatic},MaxSpeed:{MaxSpeed}";
        }
        public  void ShowCarInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($"Doors Count:{DoorsCount}");
            Console.WriteLine($"TrunkCapacity :{TrunkCapacity}");
            Console.WriteLine($" IsAutomatic:{IsAutomatic}");
            Console.WriteLine($"MaxSpeed:{MaxSpeed}");

        }
        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.50;
        }




    }
}
