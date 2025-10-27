using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Interface__Abstraction__Static_Members
{
    internal class Calculation : ICalculation
    {
       public  double Calculate (double a, double b, string operation)
        {
            if (operation == "+")
                return a + b;
            else if (operation == "-")
                return a - b;
            else if (operation == "*")
                return a * b;
            else if (operation == "/")
                return b!=0 ? a / b : a;
            else
            {
                Console.WriteLine("Yanlis emeliyyat seildi");
                return 0;

            }


        }
      
           
    }
}
