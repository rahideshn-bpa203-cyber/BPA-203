namespace _12.Interface__Abstraction__Static_Members
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation calc = new Calculation();
            Console.WriteLine("Birinci ededi daxil edin:");
            double a=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ikinci ededi daxil edin");
            double b=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Emeliyyati secin(+,-,*,/):");
            string op=Console.ReadLine();
            double result = calc.Calculate(a,b,op);
            Console.WriteLine($"Netice:{result}");

        }
    }
}
