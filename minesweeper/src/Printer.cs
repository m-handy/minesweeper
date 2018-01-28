using System;


namespace Minesweeper
{
    public static class Printer
    {
        public static void Print(Field field)
        {
            for (int i = 0; i < field.Rows; i++)
            {
                for (int j = 0; j < field.Columns; j++)
                {
                    var point = new Point(i, j);
                    Console.BackgroundColor = ConsoleColor.Gray;

                    if (point.IsMine(field))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(field.Mines[point].Output);
                    }
                    else if (point.IsNeighbor(field))
                    {
                        switch (field.MinesNeighbors[point].Value)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                        }
                        Console.Write(field.MinesNeighbors[point].Output);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.ResetColor();
                Console.Write(Environment.NewLine);
            }
        }
    }
}