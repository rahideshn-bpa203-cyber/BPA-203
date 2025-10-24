namespace _10_Access_Modifiers_Encupsulation_NameSpace
{
    internal class Program
    {   
        static void Main(string[] args)
        {

            GET get = new GET();
            get.HorsePower = 200;
            Console.WriteLine(get.HorsePower);
        }

    }
    
}
