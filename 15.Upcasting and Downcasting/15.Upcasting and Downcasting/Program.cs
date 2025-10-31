using _15.Upcasting_and_Downcasting__Explicit_and_Implicit_Finalize__Destructor_.Models;

namespace _15.Upcasting_and_Downcasting__Explicit_and_Implicit_Finalize__Destructor_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Upcasting-Downcasting
            //Dog dog = new Dog();
            //Eagle eagle = new Eagle();

            #region  Implicit - Upcasting


            // Animal animal = dog;
            // Animal animal1 = eagle;
            //Console.WriteLine(eagle.FlySpeed);

            ////Explicit-Downcasting
            ////Dog dog1=(Dog)animal;
            //Eagle eagle=(Eagle) animal1;
            //Console.WritleLine(eagle1.);
            //Animal[] animals = { eagle, dog };
            //foreach (Animal animal in animals)
            //{
            //    Eagle eagle1 = (Eagle)animal;
            //    eagle1.Fly();
            //    if (animal is Eagle)
            //    {
            //        Eagle eagle1 = (Eagle)animal;
            //        eagle1.Fly();
            //    }
            //}
            #endregion

            #endregion

            #region Boxing-Unboxing
            ////Boxing
            //int a = 5;
            //object b = a;
            ////Unboxing
            //int c = (int)b;
            //Test test = new Test();
            //object d = test;
            //ITestable testable = test; 
            #endregion

            #region Dollar-Manat cevrilmesine aid task(implicit-explicit)
            //Dollar dollar = new(200);
            //Manat manat = new(170);
            //Manat manat1 = dollar;
            //Console.WriteLine(manat1.AZN); 
            #endregion
        }

    }
    #region  struct Test,ITestable
    //public struct Test:ITestable
    //{
    //    public int x {  get; set; }
    //    public int y { get; set; }
    //}
    //public interface ITestable
    //{
    //    int y { get; set; }
    //} 
    #endregion
}
