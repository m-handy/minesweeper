using System;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Field(500,236,100_000);
            //var field = new Field(50,100,350);
            field.Print();
        }
    }
}
