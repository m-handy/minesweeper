using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            //var field = new Field(500, 236, 100_000);
            //var field = new Field(50, 150, 6550);
            var field = new Field(15, 15, 30);
            Printer.Print(field);
        }
    }
}
