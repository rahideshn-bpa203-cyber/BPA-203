using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Abstract_class__Polymorphism__ForEach.Models
{
    internal class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }
        public int MaxSpeed { get; set; }

        public Truck (string brand, string model, int year, string plateNumber, double cargoCapacity, int axleCount, int maxSpeed)
           : base(brand, model, year, plateNumber)
        {
            this.CargoCapacity = cargoCapacity;
            this.AxleCount = axleCount;
            this.CurrentLoad = 0;
            this.MaxSpeed = maxSpeed;
            

        }
       


        public override string GetVehicleInfo()
        {
            return $"Brand:{Brand},Model:{Model},Year:{Year},PlateNumber:{PlateNumber}, FuelLevel{FuelLevel}, CargoCapacity:{CargoCapacity},AxleCount:{AxleCount}, CurrentLoad :{CurrentLoad},MaxSpeed:{MaxSpeed}";
        }
       

        public void ShowTruckInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($" CargoCapacity:{CargoCapacity}");
            Console.WriteLine($"AxleCount :{AxleCount}");
            Console.WriteLine($" CurrentLoad :{CurrentLoad}");
            Console.WriteLine($"MaxSpeed:{MaxSpeed}");
            

        }
        public void LoadCargo(double weight)
        {
            if (weight>CargoCapacity)
            {
                
                Console.WriteLine("Please think about your safety");
            }
            else
            {
                Console.WriteLine("Yolunuz aciq olsun");
            
            }


        }
        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
        }

    }
}
