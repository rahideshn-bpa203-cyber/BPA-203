using System.Security.Cryptography;
using System.Text;

namespace _06_C__IntroMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    int cemi = Hesab(15, 5);
            //    Console.WriteLine(cemi);

            //int ferq = Hesab(15, 5);
            //Console.WriteLine(ferq);

            //    int vurma=Hesab(15,5);
            //    Console.WriteLine(vurma);
            //    int bolme=Hesab(15,5);
            //    Console.WriteLine(bolme);
            //
            //    Array ([14, 20, 35, 40, 57, 60, 100]);

            //}
            //Array([14, 20, 35, 40, 57, 60, 100]);
            #region Her biri 2 parametr qebul edib ve riyazi emelleri yerine yetiren method yazin
            //public static int Hesab(int a, int b)
            //{

            //    return a + b;

            //}
            //public static int Hesab(int a, int b)
            //{
            //    return a - b;
            //}

            //        public static int Hesab(int a, int b)
            //        {
            //            return (a * b);

            //        }
            //    }        public static int Hesab(int a, int b)
            //{
            //    return (a / b);
        }
        #endregion

        #region Tek ve cut ededleri tapan
        //public static void Array (params int[] Arr)
        //        {
        //          for (int i = 0; i < Arr.Length; i++) {
        //                if (Arr[i] % 2 == 0)
        //                {
        //                    Console.WriteLine("eded cutdur");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("eded tekdir");
        //                        }


        #endregion

        #region hem 4e hem 5e bolunen ededlerin cemi
        public static void Array(params int[] arr)
        {
            int cem = 0;
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] % 4 == 0 && arr[i] % 5 == 0)
                {

                    cem = cem + arr[i];
                }
                else
                {

                }



            }
            Console.WriteLine(cem); 
            #endregion
        }
    }
}




