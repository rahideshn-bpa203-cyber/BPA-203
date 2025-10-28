using _13.Nullable__Enum__Struct._NullableEnumStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Nullable__Enum__Struct.CafeOrderSystem
{

    public class DrinkOrder
    {

        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price { get; set; }

      
        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            OrderNumber = orderNumber;
            CustomerName = customerName;
            Drink = drink;
            Size = size;
            Status = OrderStatus.New;
            Price = CalculatePrice();
        }

       
        private decimal CalculatePrice()
        {
            decimal price = 0;

            switch (Drink)
            {
                case DrinkType.Coffee:
                    if (Size is DrinkSize.Small)
                        price = 3m;
                    else if (Size is DrinkSize.Medium)
                        price = 4m;
                    else if (Size is DrinkSize.Large)
                        price = 5m;
                    break;

                case DrinkType.Tea:
                    if (Size is DrinkSize.Small)
                        price = 2m;
                    else if (Size == DrinkSize.Medium)
                        price = 3m;
                    else if (Size == DrinkSize.Large)
                        price = 4m;
                    break;

                case DrinkType.Juice:
                    if (Size is DrinkSize.Small)
                        price = 4m;
                    else if (Size is DrinkSize.Medium)
                        price = 5m;
                    else if (Size is DrinkSize.Large)
                        price = 6m;
                    break;

                case DrinkType.Water:
                    if (Size is DrinkSize.Small)
                        price = 1m;
                    else if (Size is DrinkSize.Medium)
                        price = 1.5m;
                    else if (Size is DrinkSize.Large)
                        price = 2m;
                    break;
            }

            return price;
        } 
            
        

        
        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifariş #{OrderNumber} statusu: {newStatus}");
        }

       
        public void DisplayOrder()
        {
           
            Console.WriteLine($"Sifariş nömrəsi: {OrderNumber}");
            Console.WriteLine($"Müştəri: {CustomerName}");
            Console.WriteLine($"İçki: {Drink}");
            Console.WriteLine($"Ölçü: {Size}");
            Console.WriteLine($"Qiymət: {Price} AZN");
            Console.WriteLine($"Status: {Status}");
            
        }
    }
}
