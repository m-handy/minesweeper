using System;
using System.Collections.Generic;

namespace minesweeper
{
    public class Playground
    {

        private string name;
        private int rows;
        private int columns;
        private int mines;
        private int size;
        private Pole[,] x;

        public Playground(int rows, int columns, int mines, string name = "default")
        {
            x = new Pole[rows,columns];
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    x[i,j] = new Pole(i,j);
                }
                
            }
            

            this.name = name;
            size = rows * columns;
            if (mines > size)
            {
                throw new ArgumentOutOfRangeException("mines", mines, "number of mines cannot be bigger than size of field!");
            }


            Random rnd = new Random();
            var minesList = new List<int>();
            

            for (int i = 0; i < mines; i++)
            {
                int xx = rnd.Next(0, size); // creates a number between 0 and size
                while(minesList.Contains(xx)){
                    xx = rnd.Next(0, size); // creates a number between 0 and size
                }
                minesList.Add(xx);
                
                var line = xx/columns;
                var sloupec = xx%columns;

                x[line,sloupec].setMine();
            }
        }

        public string getName()
        {
            return this.name;
        }
    }
}