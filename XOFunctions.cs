using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    public class XOFunctions
    {
        //Центральная функция игры, которая определяет поле, один или два игрока играют, уровень сложности и т.д.
        public static void FunXO()
        {
            Random r = new Random();
            int counter = 1;
            string[] field = new string[] { "-", "-", "-", "-", "-", "-", "-", "-", "-" };

            Console.WriteLine("Choose how you will play: Solo or Duo?");
            string chooseMode = Console.ReadLine();
            int chooseBoolMode;

            while (chooseMode.ToLower() != "solo" && chooseMode.ToLower() != "duo")
            {
                Console.WriteLine("It's not Solo or Duo! Try again");
                chooseMode = Console.ReadLine();
            }

            if (chooseMode.ToLower() == "solo") { chooseBoolMode = 1; }
            else chooseBoolMode = 0;

            if (chooseBoolMode == 1)
            {
                Console.WriteLine($"Choose Robot-Level: Hard or Lite?");
                string chooseLVL = Console.ReadLine();
                int chooseLVLBool;

                while (chooseLVL.ToLower() != "hard" && chooseLVL.ToLower() != "lite")
                {
                    Console.WriteLine("It's not Hard or Lite! Try again");
                    chooseLVL = Console.ReadLine();
                }

                if (chooseLVL.ToLower() == "hard") { chooseLVLBool = 1; }
                else chooseLVLBool = 0;

                Console.WriteLine("Choose who are you: X or O?");
                string choose = Console.ReadLine();
                int chooseBool;

                while (choose.ToLower() != "x" && choose.ToLower() != "o")
                {
                    Console.WriteLine("It's not X or O! Try again");
                    choose = Console.ReadLine();
                }

                if (choose.ToLower() == "x") { chooseBool = 1; }
                else chooseBool = 0;

                while (true)
                {
                    int ind;

                    if (chooseBool == 0)
                    {
                        if (chooseLVLBool == 1) KRobot.MakeRobotKiller(field, "X", counter); //TEST
                        else MakeRobot(field, "X");
                        if (counter >= 3) if (VictoryCheck(field) != "") { Console.WriteLine("Oops.. You lost"); return; }
                        MakePeople(field, "O");
                        if (counter >= 3) if (VictoryCheck(field) != "") { Console.WriteLine("You won! Good job"); return; }
                    }

                    else
                    {
                        MakePeople(field, "X");
                        if (counter >= 3) if (VictoryCheck(field) != "") { Console.WriteLine("You won! Good job"); return; }
                        if (chooseLVLBool == 1) KRobot.MakeRobotKiller(field, "O", counter); //TEST
                        else MakeRobot(field, "O");
                        if (counter >= 3) if (VictoryCheck(field) != "") { Console.WriteLine("Oops.. You lost"); return; }
                    }

                    if (!field.Contains("-"))
                    {
                        Console.WriteLine("Draw!");
                        break;
                    }

                    counter++;
                }
            }
            else
            {
                while (true)
                {
                    int ind;
                    MakePeople(field, "X");
                    if (counter >= 3) if (VictoryCheck(field) != "") { Console.WriteLine($"Win: {VictoryCheck(field)}"); return; }
                    MakePeople(field, "O");
                    if (counter >= 3) if (VictoryCheck(field) != "") { Console.WriteLine($"Win: {VictoryCheck(field)}"); return; }

                    if (!field.Contains("-"))
                    {
                        Console.WriteLine("Draw!");
                        break;
                    }

                    counter++;
                }
            }
        }

        //Функция, реализующая ход робота
        public static void MakeRobot(string[] field, string str)
        {
            if (!field.Contains("-")) return;

            Random r = new Random();
            int rand = -1;

            var XOgrid = new List<string>();

            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] == "-") XOgrid.Add(field[i]);
            }

            while (rand == -1 || field[rand] != "-") rand = r.Next(0, XOgrid.Count);

            field[rand] = str;

            Console.WriteLine("The robot made a move: ");
            PrintXO(field);
            XOgrid = new List<string>();
        }

        //Функция, реализующая ход игрока
        public static void MakePeople(string[] field, string str)
        {
            if (!field.Contains("-")) return;

            int ind;
            Console.WriteLine("Choose free cell: ");
            bool indBool = int.TryParse(Console.ReadLine(), out ind);

            if (indBool == false || !(ind >= 1 && ind <= 9)) ind = ChooseIndex(indBool);

            ind--;


            while (field[ind] != "-")
            {
                Console.WriteLine("It's cell isn't free! Choose anything ather");
                indBool = int.TryParse(Console.ReadLine(), out ind);
                if (indBool == false || !(ind >= 1 && ind <= 9)) ind = ChooseIndex(indBool);
                ind--;
            }

            field[ind] = str;
            PrintXO(field);
        }

        //Проверка выбора игроком индекса
        public static int ChooseIndex(bool fl)
        {
            int ind = -1;

            while (!fl || !(ind >= 1 && ind <= 9))
            {
                Console.WriteLine("It's incorrect index for cell! Choose index 1 to 9, which free");
                fl = int.TryParse(Console.ReadLine(), out ind);
            }

            return ind;
        }

        //Вывод поля
        public static void PrintXO(string[] a)
        {
            int c = 1;
            Console.Write(String.Concat(Enumerable.Repeat("___", 7)));
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($" | {a[i]} | ");
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.Write($"\t\t| {c} |  | {c + 1} |  | {c + 2} |");
                    if (i != 8)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    c = i + 2;
                }
            }

            Console.WriteLine();
            Console.Write(String.Concat(Enumerable.Repeat($"___", 7)));
            Console.WriteLine();
        }


        //Проверка поля на победу одного из участников
        public static string VictoryCheck(string[] field)
        {
            string backStr = "";
            int[,] winsCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

            for (int i = 0; i < winsCombination.Length / 3; i++)
            {
                if (field[winsCombination[i, 0]] == field[winsCombination[i, 1]] && field[winsCombination[i, 1]] == field[winsCombination[i, 2]] && field[winsCombination[i, 0]] != "-")
                    backStr = field[winsCombination[i, 0]];
            }

            return backStr;
        }

        //Ход робота в рандомное место на свободное поле
        public static void PushXO(string[] field)
        {
            Random r = new Random();
            int rand = -1;

            var XOgrid = new List<string>();

            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] == "-") XOgrid.Add(field[i]);
            }

            while (rand == -1 || field[rand] == "-") rand = r.Next(0, XOgrid.Count);

            field[rand] = "X";
        }
    }
}
