using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Access_Modifiers_Encupsulation_NameSpace
{
    internal class GET

    {
        private int _HorsePower;
        public int HorsePower
        {
            get { return _HorsePower; }
            set 
            {
                if (value < 100) ;
                Console.WriteLine("Please set correct power");
                return;
            
            
            
            }
            

        }

       












    }
}
