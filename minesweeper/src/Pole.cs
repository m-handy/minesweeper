using System;

namespace minesweeper{
    public class Pole{
        private bool hasMine = false;

        private int row;
        private int column;
        public Pole(int row, int column, bool hasMine = false)
        {
            this.row=row;
            this.column=column;
            this.hasMine=hasMine;
        }

        public void setMine(){
            this.hasMine=true;
            Console.WriteLine("[{0},{1}]minaaaaaaa!!!!!!", row,column);
        }
    }
}