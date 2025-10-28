using _13.Nullable__Enum__Struct._NullableEnumStruct;
using _13.Nullable__Enum__Struct.CafeOrderSystem;

namespace CafeOrderSystem
{




    internal class Program
    {
        static void Main(string[] args)
        {

            var order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
            var order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            var order3 = new DrinkOrder(103, "Vüqar", DrinkType.Juice, DrinkSize.Small);


            order1.DisplayOrder();
            order2.DisplayOrder();
            order3.DisplayOrder();


            order1.UpdateStatus(OrderStatus.Preparing);
            order1.UpdateStatus(OrderStatus.Ready);
            order1.UpdateStatus(OrderStatus.Delivered);

            order2.UpdateStatus(OrderStatus.Ready);


            Console.WriteLine(" DrinkType dəyərləri");
            foreach (var drink in Enum.GetValues(typeof(DrinkType)))
                Console.WriteLine(drink);

            Console.WriteLine("DrinkSize dəyərləri");
            foreach (var size in Enum.GetValues(typeof(DrinkSize)))
                Console.WriteLine(size);

            Console.WriteLine("OrderStatus dəyərləri");
            foreach (var status in Enum.GetValues(typeof(OrderStatus)))
                Console.WriteLine(status);



            Console.WriteLine(DrinkType.Coffee.ToString());
            Console.WriteLine(DrinkSize.Large.ToString());


            var parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
            var parsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");

            Console.WriteLine($"Parse nəticələri: {parsedDrink}, {parsedSize}");

            Console.WriteLine($"Ümumi sifariş sayı: 3");
            Console.WriteLine($"1-ci sifariş qiyməti: {order1.Price} AZN");
            Console.WriteLine($"2-ci sifariş qiyməti: {order2.Price} AZN");
            Console.WriteLine($"3-cü sifariş qiyməti: {order3.Price} AZN");
            Console.WriteLine($"Ümumi məbləğ: {order1.Price + order2.Price + order3.Price} AZN");
        }
    }
} 
    
    
    
       


     
    

    
    



        

