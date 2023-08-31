using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{
    public class KRobot
    {
        //------------------------------ XO-Robot ------------------------------
        static bool fl;
        static int v;
        static int i = -1;

        public static void MakeRobotKiller(string[] field, string str, int counter)
        {

            if (!field.Contains("-")) return;

            //------------------------------ X-Robot ------------------------------
            if (str == "X")
            {
                if (counter == 1) field[4] = str;

                else if (counter == 2)
                {
                    if (field[1] != "-" || field[3] != "-" || field[5] != "-" || field[7] != "-")
                    {
                        if (field[1] != "-" || field[5] != "-") field[2] = "X";
                        else if (field[3] != "-" || field[7] != "-") field[6] = "X";
                    }

                    else
                    {
                        if (field[0] == "O") field[6] = "X";
                        else if (field[2] == "O") field[8] = "X";
                        else if (field[6] == "O") field[0] = "X";
                        else field[2] = "X";
                    }
                }

                else if (counter == 3 && (field[2] == "X" || field[6] == "X") && (field[1] == "-" || field[3] == "-" || field[5] == "-" || field[7] == "-"))
                {
                    fl = true;
                    if (field[2] == "X" && field[1] == "O")
                    {
                        if (field[6] == "-") field[6] = "X";
                        else field[8] = "X";
                    }
                    else if (field[2] == "X" && field[5] == "O")
                    {
                        if (field[6] == "-") field[6] = "X";
                        else field[0] = "X";
                    }
                    else if (field[2] == "X")
                    {
                        if (field[6] == "-") field[6] = "X";
                        else if (field[0] == "-") field[0] = "X";
                        else if (field[8] == "-") field[8] = "X";
                    }
                    else if (field[6] == "X" && field[3] == "O")
                    {
                        if (field[2] == "-") field[2] = "X";
                        else field[8] = "X";
                    }
                    else if (field[6] == "X" && field[7] == "O")
                    {
                        if (field[2] == "-") field[2] = "X";
                        else field[0] = "X";
                    }
                    else if (field[6] == "X")
                    {
                        if (field[2] == "-") field[2] = "X";
                        else if (field[0] == "-") field[0] = "X";
                        else if (field[8] == "-") field[8] = "X";
                    }
                }

                else if (counter == 3 && (field[1] == "-" || field[3] == "-" || field[5] == "-" || field[7] == "-"))
                {
                    if (field[0] == "O" && field[2] == "O") field[1] = "X";
                    if (field[2] == "O" && field[8] == "O") field[5] = "X";
                    if (field[0] == "O" && field[6] == "O") field[3] = "X";
                    if (field[6] == "O" && field[8] == "O") field[7] = "X";
                }

                else if (counter == 3)
                {
                    if (field[2] == "X" && field[6] == "-") field[6] = "X";
                    else if (field[2] == "X" && field[6] != "-") { field[5] = "X"; v = 1; }

                    else if (field[8] == "X" && field[0] == "-") field[0] = "X";
                    else if (field[8] == "X" && field[0] != "-") { field[5] = "X"; v = 2; }

                    else if (field[0] == "X" && field[8] == "-") field[8] = "X";
                    else if (field[0] == "X" && field[8] != "-") { field[3] = "X"; v = 3; }

                    else if (field[6] == "X" && field[2] == "-") field[2] = "X";
                    else if (field[6] == "X" && field[2] != "-") { field[3] = "X"; v = 4; }
                }

                else if (counter == 4 && fl == true)
                {
                    if (field[2] == "X" && field[8] == "X")
                    {
                        if (field[5] == "-") field[5] = "X";
                        else if (field[3] == "-") field[3] = "X";
                        else XOFunctions.PushXO(field);
                    }
                    else if (field[2] == "X" && field[0] == "X")
                    {
                        if (field[8] == "-") field[8] = "X";
                        else if (field[1] == "-") field[1] = "X";
                        else XOFunctions.PushXO(field);
                    }
                    else if (field[6] == "X" && field[8] == "X")
                    {
                        if (field[0] == "-") field[0] = "X";
                        else if (field[7] == "-") field[7] = "X";
                        else XOFunctions.PushXO(field);
                    }
                    else if (field[6] == "X" && field[0] == "X")
                    {
                        if (field[8] == "-") field[8] = "X";
                        else if (field[3] == "-") field[3] = "X";
                        else XOFunctions.PushXO(field);
                    }
                }

                else if (counter == 4)
                {
                    if (field[3] == "X")
                    {
                        if (field[5] == "-") field[5] = "X";
                        else if (field[1] == "-") field[1] = "X";
                        else XOFunctions.PushXO(field);
                    }
                    else if (field[1] == "X")
                    {
                        if (field[7] == "-") field[7] = "X";
                        else if (field[3] == "-") field[3] = "X";
                        else XOFunctions.PushXO(field);
                    }
                    else if (field[7] == "X")
                    {
                        if (field[1] == "-") field[1] = "X";
                        else if (field[5] == "-") field[5] = "X";
                        else XOFunctions.PushXO(field);
                    }
                    else if (field[3] == "X")
                    {
                        if (field[5] == "-") field[5] = "X";
                        else if (field[3] == "-") field[3] = "X";
                        else XOFunctions.PushXO(field);
                    }
                }

                else if (counter == 5)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (field[i] == "-") { field[i] = "X"; break; }
                    }
                }
            }

            //------------------------------ O-Robot ------------------------------

            else
            {
                Random r = new Random();

                if (counter == 1 && field[4] == "-") field[4] = "O";

                else if (counter == 1 && field[4] != "-")
                {
                    while (i != 0 && i != 2 && i != 6 && i != 8) i = r.Next(0, 8);
                    field[i] = "O";
                }

                else if (counter >= 2)
                {
                    int[,] winsCombination = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
                    bool fl = false;
                    bool flW = false;

                    for (int i = 0; i < winsCombination.Length / 3; i++)
                    {
                        if ((field[winsCombination[i, 0]] == field[winsCombination[i, 1]] || field[winsCombination[i, 1]] == field[winsCombination[i, 2]] || field[winsCombination[i, 0]] == field[winsCombination[i, 2]]) && ((field[winsCombination[i, 0]] == "O" && field[winsCombination[i, 1]] == "O") || (field[winsCombination[i, 2]] == "O" && field[winsCombination[i, 1]] == "O") || (field[winsCombination[i, 2]] == "O" && field[winsCombination[i, 0]] == "O")))
                        {
                            if (field[winsCombination[i, 0]] == "-") { field[winsCombination[i, 0]] = "O"; flW = true; break; }
                            else if (field[winsCombination[i, 1]] == "-") { field[winsCombination[i, 1]] = "O"; flW = true; break; }
                            else if (field[winsCombination[i, 2]] == "-") { field[winsCombination[i, 2]] = "O"; flW = true; break; }
                        }
                    }

                    if (!flW)
                    {
                        for (int i = 0; i < winsCombination.Length / 3; i++)
                        {
                            if ((field[winsCombination[i, 0]] == field[winsCombination[i, 1]] || field[winsCombination[i, 1]] == field[winsCombination[i, 2]] || field[winsCombination[i, 0]] == field[winsCombination[i, 2]]) && ((field[winsCombination[i, 0]] == "X" && field[winsCombination[i, 1]] == "X") || (field[winsCombination[i, 2]] == "X" && field[winsCombination[i, 1]] == "X") || (field[winsCombination[i, 2]] == "X" && field[winsCombination[i, 0]] == "X")))
                            {
                                if (field[winsCombination[i, 0]] == "-") { field[winsCombination[i, 0]] = "O"; fl = true; break; }
                                else if (field[winsCombination[i, 1]] == "-") { field[winsCombination[i, 1]] = "O"; fl = true; break; }
                                else if (field[winsCombination[i, 2]] == "-") { field[winsCombination[i, 2]] = "O"; fl = true; break; }
                            }
                        }
                    }

                    if (!fl)
                    {
                        if (counter == 2)
                        {
                            if (field[1] != "-" || field[3] != "-" || field[5] != "-" || field[7] != "-")
                            {
                                if (field[1] != "-" || field[5] != "-") field[2] = "O";
                                else if (field[3] != "-" || field[7] != "-") field[6] = "O";
                            }

                            else
                            {
                                if (field[0] == "X") field[2] = "O";
                                else if (field[2] == "X") field[8] = "O";
                                else if (field[6] == "X") field[0] = "O";
                                else field[2] = "O";
                            }
                        }

                        else if (counter == 3 && (field[2] == "O" || field[6] == "O") && (field[1] != "-" || field[3] != "-" || field[5] != "-" || field[7] != "-"))
                        {
                            fl = true;
                            if (field[2] == "O" && field[1] == "X")
                            {
                                if (field[6] == "-") field[6] = "O";
                                else field[8] = "O";
                            }
                            else if (field[2] == "O" && field[5] == "X")
                            {
                                if (field[6] == "-") field[6] = "O";
                                else field[0] = "O";
                            }
                            else if (field[6] == "O" && field[3] == "X")
                            {
                                if (field[2] == "-") field[2] = "O";
                                else field[8] = "O";
                            }
                            else if (field[6] == "O" && field[7] == "X")
                            {
                                if (field[2] == "-") field[2] = "O";
                                else field[0] = "O";
                            }
                        }

                        else if (counter == 3 && (field[1] == "-" || field[3] == "-" || field[5] == "-" || field[7] == "-"))
                        {
                            if (field[0] == "X" && field[2] == "X") field[1] = "O";
                            if (field[2] == "X" && field[8] == "X") field[5] = "O";
                            if (field[0] == "X" && field[6] == "X") field[3] = "O";
                            if (field[6] == "X" && field[8] == "X") field[7] = "O";
                        }

                        else if (counter == 3)
                        {
                            if (field[2] == "O" && field[6] == "-") field[6] = "O";
                            else if (field[2] == "O" && field[6] != "-") { field[5] = "O"; v = 1; }

                            else if (field[8] == "O" && field[0] == "-") field[0] = "O";
                            else if (field[8] == "O" && field[0] != "-") { field[5] = "O"; v = 2; }

                            else if (field[0] == "O" && field[8] == "-") field[8] = "O";
                            else if (field[0] == "O" && field[8] != "-") { field[3] = "O"; v = 3; }

                            else if (field[6] == "O" && field[2] == "-") field[2] = "O";
                            else if (field[6] == "O" && field[2] != "-") { field[3] = "O"; v = 4; }
                        }

                        else if (counter == 4 && fl == true)
                        {
                            if (field[2] == "O" && field[8] == "O")
                            {
                                if (field[0] == "-") field[0] = "O";
                                else field[5] = "O";
                            }
                            else if (field[2] == "O" && field[0] == "O")
                            {
                                if (field[8] == "-") field[8] = "O";
                                else field[1] = "O";
                            }
                            else if (field[6] == "O" && field[8] == "O")
                            {
                                if (field[0] == "-") field[0] = "O";
                                else field[7] = "O";
                            }
                            else if (field[6] == "O" && field[0] == "O")
                            {
                                if (field[8] == "-") field[8] = "O";
                                else field[3] = "O";
                            }
                        }

                        else if (counter == 4)
                        {
                            if (field[3] == "O")
                            {
                                if (field[5] == "-") field[5] = "O";
                                else field[1] = "O";
                            }
                            else if (field[1] == "O")
                            {
                                if (field[7] == "-") field[7] = "O";
                                else field[3] = "O";
                            }
                            else if (field[7] == "O")
                            {
                                if (field[1] == "-") field[1] = "O";
                                else field[5] = "O";
                            }
                            else if (field[3] == "O")
                            {
                                if (field[5] == "-") field[5] = "O";
                                else field[3] = "O";
                            }
                        }

                        else if (counter == 5)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                if (field[i] == "-") { field[i] = "O"; break; }
                            }
                        }

                    }
                }
            }

            Console.WriteLine("The robot made a move: ");
            XOFunctions.PrintXO(field);
        }
    }
}
