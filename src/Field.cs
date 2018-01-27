using System;

namespace minesweeper
{
    public class Field
    {

        private string name;
        private int rows;
        private int columns;
        private int mines;

        private int size;

        public Field(int rows, int columns, int mines, string name = "default")
        {
            size = rows * columns;
            if (mines > size)
            {
                throw new ArgumentOutOfRangeException("mines", mines, "number of mines cannot be bigger than size of field!");
            }
        }

        public string getName()
        {
            return this.name;
        }
    }
}