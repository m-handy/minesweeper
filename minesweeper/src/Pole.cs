using System;

namespace minesweeper{
    public class Pole{
        private int row;
        private int column;

        private int value;
        public Pole(int row, int column)
        {
            this.row=row;
            this.column=column;
        }

        internal void SetValue(int value)
        {
            this.value = value;
        }

        internal int GetValue()
        {
            return value;
        }
    }
}