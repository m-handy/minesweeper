using System;
using System.Collections.Generic;

namespace minesweeper
{
    public class Playground
    {
        private int rows;
        private int columns;
        private int mines;
        private int size;
        private Pole[,] playground;

        public Playground(int rows, int columns, int mines)
        {
            this.rows = rows;
            this.columns = columns;
            this.size = rows * columns;
            if (mines > size)
            {
                throw new ArgumentOutOfRangeException("mines", mines, "number of mines cannot be bigger than size of field!");
            }
            this.mines = mines;
            var minesList = createMinesList();
            createPlayground(minesList);
        }

        private void createPlayground(List<Tuple<int,int>> minesList){
            playground = new Pole[rows,columns];
            for (int i = 0; i < playground.GetLength(0); i++)
            {
                for (int j = 0; j < playground.GetLength(1); j++)
                {
                    var hasMine = minesList.Contains(Tuple.Create(i,j));
                    playground[i,j] = new Pole(i,j,hasMine);
                }    
            }
        }

        private List<Tuple<int,int>> createMinesList(){
            Random rnd = new Random();
            var minesList = new List<int>();
            var minesPositionList = new List<Tuple<int,int>>();

            for (int i = 0; i < mines; i++)
            {
                int xx = rnd.Next(0, size); // creates a number between 0 and size
                while(minesList.Contains(xx)){
                    xx = rnd.Next(0, size); // creates a number between 0 and size
                }
                minesList.Add(xx); 
                ;
                minesPositionList.Add(Tuple.Create(xx/columns, xx%columns));
            }


            return minesPositionList;
        }
    }
}