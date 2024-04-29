using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace XO
{
    class XO
    {
        static public int chooseBoolMode = -1;
        static public int chooseLVLBool = -1;
        static public int chooseBool = -1;

        static void Main(string[] args)
        {
            Console.WriteLine("---- XO Project ----");

            XOFunctions.FunXO(-2, -2, -2);

            while (true)
            {
                Console.WriteLine("Do you want play more: Yes(y) or No(n)?\nIf you want to play without changing settings: YesWithout(yw)");
                string choose = Console.ReadLine();
                int chooseBool = 0;

                while (choose.ToLower() != "yes" && choose.ToLower() != "y" && choose.ToLower() != "no" && choose.ToLower() != "n" && choose.ToLower() != "YesWithout" && choose.ToLower() != "yw")
                {
                    Console.WriteLine("It's not Yes(y) or No(n) [or YesWithout(yw)]! Try again");
                    choose = Console.ReadLine();
                }

                if (choose.ToLower() == "yes" || choose.ToLower() == "y") { chooseBool = 1; XOFunctions.FunXO(); }
                else if (choose.ToLower() == "YesWithout" || choose.ToLower() == "yw") { XOFunctions.FunXO(chooseBoolMode, chooseLVLBool, chooseBool); }
                else break;
            }
        }

    }
}