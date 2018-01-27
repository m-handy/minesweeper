using System;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Field(3,5,30);
            Console.WriteLine(field.getName());  
       
        }
    }
}
