using System;
using System.Linq;

namespace XO
{
    public class KRobot
    {
        public static void MakeRobotKiller(string[] field, string str, int counter)
        {
            if (!field.Contains("-")) return;

            Random r = new Random();
            int rand;

            if (counter == 1)
            {
                if (field[4] == "-") rand = 4;
                else
                {
                    int[] angleIndex = { 0, 2, 6, 8 };
                    rand = angleIndex[r.Next(0, angleIndex.Length)];
                }
            }
            else
            {
                int[,] winsCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

                for (int i = 0; i < winsCombination.GetLength(0); i++)
                {
                    if (field[winsCombination[i, 0]] == field[winsCombination[i, 1]] && field[winsCombination[i, 1]] == str && field[winsCombination[i, 2]] == "-")
                    {
                        rand = winsCombination[i, 2];
                        field[rand] = str;
                        Console.WriteLine("The robot made a move: ");
                        XOFunctions.PrintXO(field);
                        return;
                    }
                    else if (field[winsCombination[i, 0]] == field[winsCombination[i, 2]] && field[winsCombination[i, 2]] == str && field[winsCombination[i, 1]] == "-")
                    {
                        rand = winsCombination[i, 1];
                        field[rand] = str;
                        Console.WriteLine("The robot made a move: ");
                        XOFunctions.PrintXO(field);
                        return;
                    }
                    else if (field[winsCombination[i, 1]] == field[winsCombination[i, 2]] && field[winsCombination[i, 2]] == str && field[winsCombination[i, 0]] == "-")
                    {
                        rand = winsCombination[i, 0];
                        field[rand] = str;
                        Console.WriteLine("The robot made a move: ");
                        XOFunctions.PrintXO(field);
                        return;
                    }
                }

                rand = r.Next(0, field.Length);

                while (field[rand] != "-")
                {
                    rand = r.Next(0, field.Length);
                }
            }

            field[rand] = str;

            Console.WriteLine("The robot made a move: ");
            XOFunctions.PrintXO(field);
        }
    }
}
