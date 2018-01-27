using System;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Playground(3,5,6);
            Console.WriteLine(field.getName());
        }
    }
}
