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

        private void createPlayground(List<Tuple<int, int>> minesList)
        {
            playground = new Pole[rows, columns];
            for (int i = 0; i < playground.GetLength(0); i++)
            {
                for (int j = 0; j < playground.GetLength(1); j++)
                {
                    if (minesList.Contains(Tuple.Create(i, j)))
                    {
                        playground[i, j] = new Mine(i, j);
                    }
                    else
                    {
                        playground[i, j] = new Pole(i, j);
                    }
                }
            }


            for (int i = 0; i < playground.GetLength(0); i++)
            {
                for (int j = 0; j < playground.GetLength(1); j++)
                {
                    if (playground[i, j].GetType() != typeof(Mine))
                    {
                        var value = 0;
                        if (i > 0)
                        {
                            if (j > 0)
                            {
                                if (playground[i - 1, j - 1].GetType() == typeof(Mine))
                                {
                                    value++;
                                }
                            }
                            if (playground[i - 1, j].GetType() == typeof(Mine))
                            {
                                value++;
                            }
                            if (j < columns - 1)
                            {
                                if (playground[i - 1, j + 1].GetType() == typeof(Mine))
                                {
                                    value++;
                                }
                            }
                        }
                        if (j > 0)
                        {
                            if (playground[i, j - 1].GetType() == typeof(Mine))
                            {
                                value++;
                            }
                        }
                        if (j < columns - 1)
                        {
                            if (playground[i, j + 1].GetType() == typeof(Mine))
                            {
                                value++;
                            }
                        }

                        if (i < rows - 1)
                        {
                            if (j > 0)
                            {
                                if (playground[i + 1, j - 1].GetType() == typeof(Mine))
                                {
                                    value++;
                                }
                            }
                            if (playground[i + 1, j].GetType() == typeof(Mine))
                            {
                                value++;
                            }
                            if (j < columns - 1)
                            {
                                if (playground[i + 1, j + 1].GetType() == typeof(Mine))
                                {
                                    value++;
                                }
                            }
                        }

                        playground[i, j].SetValue(value);
                    }
                }
            }
        }

        private List<Tuple<int, int>> createMinesList()
        {
            Random rnd = new Random();
            var minesList = new List<int>();
            var minesPositionList = new List<Tuple<int, int>>();

            for (int i = 0; i < mines; i++)
            {
                int xx = rnd.Next(0, size); // creates a number between 0 and size
                while (minesList.Contains(xx))
                {
                    xx = rnd.Next(0, size); // creates a number between 0 and size
                }
                minesList.Add(xx);
                ;
                minesPositionList.Add(Tuple.Create(xx / columns, xx % columns));
            }


            return minesPositionList;
        }


        public void Print(){
            for (int i = 0; i < playground.GetLength(0); i++)
            {
                for (int j = 0; j < playground.GetLength(1); j++)
                {
                    if (playground[i, j].GetType() == typeof(Mine))
                    {
                        Console.Write(" X ");
                    }
                    else
                    {
                        Console.Write(" " + playground[i, j].GetValue() + " ");
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}