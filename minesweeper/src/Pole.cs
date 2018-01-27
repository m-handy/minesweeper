using System;

namespace minesweeper{
    public class Pole{
        private bool hasMine = false;

        private int row;
        private int column;
        public Pole(int row, int column)
        {
            this.row=row;
            this.column=column;
        }

        public void setMine(){
            this.hasMine=true;
            Console.WriteLine("[{0},{1}]minaaaaaaa!!!!!!", row,column);
        }
    }
}