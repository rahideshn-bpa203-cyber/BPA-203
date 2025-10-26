using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Abstract_class__Polymorphism__ForEach.Models
{
    internal class Motorcycle :Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public int MaxSpeed { get; set; }
        public string Type { get; set; }

        public Motorcycle(string brand, string model, int year, string plateNumber, int engineCapacity, bool hasSidecar, int maxSpeed,string type)
           : base(brand, model, year, plateNumber)
        {
            this.EngineCapacity = engineCapacity;
            this.HasSidecar = hasSidecar;
            this.MaxSpeed =maxSpeed ;
            this.Type = type;

        }
       
        public override string GetVehicleInfo()
        {
            return $"Brand:{Brand},Model:{Model},Year:{Year},PlateNumber:{PlateNumber},FuelLevel{FuelLevel},EngineCapacity:{EngineCapacity},HasSidecar:{HasSidecar},MaxSpeed:{MaxSpeed},Type:{Type}";
        }
       

        public void ShowMotorcycleInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($"EngineCapacity :{EngineCapacity}");
            Console.WriteLine($"HasSidecar :{HasSidecar}");
            Console.WriteLine($"MaxSpeed:{MaxSpeed}");
            Console.WriteLine($"Type{Type}");

        }
        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 4 * 1.50;
        }


    }
}
