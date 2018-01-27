using System;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Playground(10,10,1);
            field.Print();
        }
    }
}
