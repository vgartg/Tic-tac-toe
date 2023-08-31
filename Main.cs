using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace XO
{
    class XO
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- XO Project ----");

            XOFunctions.FunXO();

            while (true)
            {
                Console.WriteLine("Do u want play more: Yes or No?");
                string choose = Console.ReadLine();
                int chooseBool = 0;

                while (choose.ToLower() != "yes" && choose.ToLower() != "no")
                {
                    Console.WriteLine("It's not Yes or No! Try again");
                    choose = Console.ReadLine();
                }

                if (choose.ToLower() == "yes") { chooseBool = 1; XOFunctions.FunXO(); }
                else break;
            }
        }
        
    }
}