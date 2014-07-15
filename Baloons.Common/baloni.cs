using System;
using System.Collections.Generic;
using ConsoleApplication1;

// kolko me cepi glavata, piqna sym ot vcera, sha vyrna li vodkata ili sha ya poema, dajte mi bira, da iztrezneyaaa

namespace Balloons_Pops_game
{
    class baloni
    {
        static byte[,] GenerateInner(byte rows, byte columns)
        {
            byte[,] matrix = new byte[rows, columns];
            Random rnd = new Random();
            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte rndNum = (byte)rnd.Next(1, 5);
                    matrix[row, column] = rndNum;
                }
            }
            return matrix;
        }

        static void checkLeft(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkLeft(matrix, newRow, newColumn, searchedItem);
                }
                else
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void checkRight(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkRight(matrix, newRow, newColumn, searchedItem);
                }
                else
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void checkUp(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row + 1;
            int newColumn = column ;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkUp(matrix, newRow, newColumn, searchedItem);
                }
                else
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void checkDown(byte[,] matrix, int row, int column, int searchedItem)
        {
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (matrix[newRow, newColumn] == searchedItem)
                {
                    matrix[newRow, newColumn] = 0;
                    checkDown(matrix, newRow, newColumn, searchedItem);
                }
                else
                    return;
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static bool change(byte[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 0)
            {
                return true;
            }
            byte target = matrix[row, col];
            matrix[row, col] = 0;
            checkLeft(matrix, row, col, target);
            checkRight(matrix, row, col, target);

            checkUp(matrix, row, col, target);
            checkDown(matrix, row, col, target);
            return false;
        }

        static bool doit(byte[,] matrix)
        {
            bool isWinner = true;
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isWinner = false;
                        stek.Push(matrix[i, j]);
                    }
                }
                for (int k = columnLenght - 1; (k >= 0); k--)
                {
                    try
                    {
                        matrix[k, j] = stek.Pop(); 
                    }
                    catch (Exception)
                    {
                        matrix[k, j] = 0;
                    }
                }
            }
            return isWinner;
        }

        static void PrintChart(string[,] tableToSort)
        {
            List<Chart> chart = new List<Chart>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null) 
                { 
                    break; 
                }
                
                chart.Add(new Chart(int.Parse(tableToSort[i, 0]),tableToSort[i, 1]));
            }
            
            chart.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < chart.Count; ++i)
            {
                Chart slot = chart[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");
        }

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] matrix = GenerateInner(5, 10);

            Console.Write("    ");
            for (byte column = 0; column < matrix.GetLongLength(1); column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n   ");
            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();        

            for (byte i = 0; i < matrix.GetLongLength(0); i++)  
            {
                Console.Write(i + " | ");
                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");     //some trinket stuff again
            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            string temp = null;
            int userMoves = 0;
            while (temp != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");                
                temp = Console.ReadLine();
                temp = temp.ToUpper().Trim();
                
                switch (temp) 
                {
                    case "RESTART":
                        matrix = GenerateInner(5, 10);
                        Console.Write("    ");
                        for (byte column = 0; column < matrix.GetLongLength(1); column++)
                        {
                            Console.Write(column + " ");
                        }

                        Console.Write("\n   ");
                        for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
                        {
                            Console.Write("-");
                        }

                        Console.WriteLine();

                        for (byte i = 0; i < matrix.GetLongLength(0); i++)  
                        {
                            Console.Write(i + " | ");
                            for (byte j = 0; j < matrix.GetLongLength(1); j++)
                            {
                                if (matrix[i, j] == 0)
                                {
                                    Console.Write("  ");
                                    continue;
                                }

                                Console.Write(matrix[i, j] + " ");
                            }
                            Console.Write("| ");
                            Console.WriteLine();
                        }

                        Console.Write("   ");     //some trinket stuff again
                        for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();
                        userMoves = 0;
                        break;
                    case "TOP":
                        PrintChart(topFive);
                        break;
                    default :
                        if ((temp.Length == 3) && (temp[0] >= '0' && temp[0] <= '9') && (temp[2] >= '0' && temp[2] <= '9') && (temp[1] == ' ' || temp[1] == '.' || temp[1] == ','))
                        {
                            int userRow, userColumn;
                            userRow = int.Parse(temp[0].ToString());
                            if (userRow > 4) 
                            {
                                Console.WriteLine("Wrong input ! Try Again ! ");
                                continue;
                            }
                            userColumn = int.Parse(temp[2].ToString());
                            
                            if (change(matrix, userRow, userColumn))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }
                            userMoves++;
                            if (doit(matrix))
                            {
                                Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                                if (topFive.signIfSkilled(userMoves))
                                {
                                    PrintChart(topFive);
                                }
                                else 
                                {
                                    Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                                }
                                matrix = GenerateInner(5, 10);
                                userMoves = 0;
                            }
                            Console.Write("    ");
                            for (byte column = 0; column < matrix.GetLongLength(1); column++)
                            {
                                Console.Write(column + " ");
                            }

                            Console.Write("\n   ");
                            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
                            {
                                Console.Write("-");
                            }

                            Console.WriteLine();

                            for (byte i = 0; i < matrix.GetLongLength(0); i++)  
                            {
                                Console.Write(i + " | ");
                                for (byte j = 0; j < matrix.GetLongLength(1); j++)
                                {
                                    if (matrix[i, j] == 0)
                                    {
                                        Console.Write("  ");
                                        continue;
                                    }

                                    Console.Write(matrix[i, j] + " ");
                                }
                                Console.Write("| ");
                                Console.WriteLine();
                            }

                            Console.Write("   ");     //some trinket stuff again
                            for (byte column = 0; column < matrix.GetLongLength(1) * 2 + 1; column++)
                            {
                                Console.Write("-");
                            }
                            Console.WriteLine();
                            break;
                        }
                        else
                        { 
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            break;
                        }
                }
            }
            Console.WriteLine("Good Bye! ");
        }
    }
}