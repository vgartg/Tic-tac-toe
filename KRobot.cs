using System;
using System.Collections.Generic;
using System.Linq;

namespace XO
{
    public class KRobot
    {
        private static Random random = new Random();

        public static void MakeRobotKiller(string[] field, string str, int counter)
        {
            if (!field.Contains("-"))
                return;

            if (str == "X")
                MakeXMove(field, counter);
            else
                MakeOMove(field, counter);

            Console.WriteLine("The robot made a move: ");
            XOFunctions.PrintXO(field);
        }

        private static void MakeXMove(string[] field, int counter)
        {
            switch (counter)
            {
                case 1:
                    field[4] = "X";
                    break;
                case 2:
                    MakeSecondMoveX(field);
                    break;
                case 3:
                    MakeThirdMoveX(field);
                    break;
                case 4:
                    MakeFourthMoveX(field);
                    break;
                case 5:
                    MakeFifthMoveX(field);
                    break;
                default:
                    break;
            }
        }

        private static void MakeSecondMoveX(string[] field)
        {
            if (field[1] != "-" || field[5] != "-")
                field[2] = "X";
            else if (field[3] != "-" || field[7] != "-")
                field[6] = "X";
            else
            {
                if (field[0] == "O") field[6] = "X";
                else if (field[2] == "O") field[8] = "X";
                else if (field[6] == "O") field[0] = "X";
                else field[2] = "X";
            }
        }

        private static void MakeThirdMoveX(string[] field)
        {
            if (!TryCompleteLine(field, "X"))
                MakeRandomXMove(field);
        }

        private static void MakeFourthMoveX(string[] field)
        {
            if (!TryCompleteLine(field, "X"))
                MakeRandomXMove(field);
        }

        private static void MakeFifthMoveX(string[] field)
        {
            if (!TryCompleteLine(field, "X"))
                MakeRandomXMove(field);
        }

        private static void MakeOMove(string[] field, int counter)
        {
            if (counter == 1)
            {
                if (field[4] == "-")
                    field[4] = "O";
                else
                    MakeRandomOMove(field);
            }
            else
            {
                if (!TryCompleteLine(field, "O") && !TryCompleteLine(field, "X"))
                    MakeRandomOMove(field);
            }
        }

        private static bool TryCompleteLine(string[] field, string marker)
        {
            int[,] winningCombinations = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // горизонтали
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // вертикали
                {0, 4, 8}, {2, 4, 6}             // диагонали
            };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                int count = 0;
                int emptyIndex = -1;
                for (int j = 0; j < 3; j++)
                {
                    if (field[winningCombinations[i, j]] == marker)
                    {
                        count++;
                    }
                    else if (field[winningCombinations[i, j]] == "-")
                    {
                        emptyIndex = winningCombinations[i, j];
                    }
                }

                if (count == 2 && emptyIndex != -1)
                {
                    field[emptyIndex] = "O";
                    return true;
                }
            }

            return false;
        }

        private static void MakeRandomOMove(string[] field)
        {
            int index = random.Next(0, 9);
            while (field[index] != "-")
            {
                index = random.Next(0, 9);
            }
            field[index] = "O";
        }

        private static void MakeRandomXMove(string[] field)
        {
            int index = random.Next(0, 9);
            while (field[index] != "-")
            {
                index = random.Next(0, 9);
            }
            field[index] = "X";
        }
    }
}