using System;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            //var field = new Playground(500,270,50_000);
            var field = new Playground(5,10,10);
            field.Print();
        }
    }
}
