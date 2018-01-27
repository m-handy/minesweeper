using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace minesweeper
{
    public class Playground
    {
        private int rows;
        private int columns;
        private int minesCout;
        private int playgroundSize;
        private Dictionary<Point, Field> playground = new Dictionary<Point, Field>();

        public Playground(int rows, int columns, int minesCount)
        {
            playgroundSize = rows * columns;
            if (minesCount > playgroundSize)
            {
                throw new ArgumentOutOfRangeException("mines", minesCount, "number of mines cannot be bigger than size of the field!");
            }

            this.rows = rows;
            this.columns = columns;
            this.minesCout = minesCount;

            LayMines();
            FillRestPlayground();
        }

        public void Print()
        {
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var point = new Point(i, j);
                    Console.Write(playground[point].Print());
                }
                Console.Write(Environment.NewLine);
            }
            watch.Stop();
            Console.WriteLine("Print: {0}ms", watch.ElapsedMilliseconds);
        }

        private bool IsMine(Point point)
        {
            return playground.ContainsKey(point) && playground[point] is Mine;
        }

        private int GetValue(Point point)
        {
            return GetValue(point.X, point.Y);
        }
        private int GetValue(int i, int j)
        {
            var value = 0;
            if (i > 0)
            {
                if (j > 0)
                {
                    if (IsMine(new Point(i - 1, j - 1)))
                    {
                        value++;
                    }
                }
                if (IsMine(new Point(i - 1, j)))
                {
                    value++;
                }
                if (j < columns - 1)
                {
                    if (IsMine(new Point(i - 1, j + 1)))
                    {
                        value++;
                    }
                }
            }

            if (j > 0)
            {
                if (IsMine(new Point(i, j - 1)))
                {
                    value++;
                }
            }
            if (j < columns - 1)
            {
                if (IsMine(new Point(i, j + 1)))
                {
                    value++;
                }
            }

            if (i < rows - 1)
            {
                if (j > 0)
                {
                    if (IsMine(new Point(i + 1, j - 1)))
                    {
                        value++;
                    }
                }
                if (IsMine(new Point(i + 1, j)))
                {
                    value++;
                }
                if (j < columns - 1)
                {
                    if (IsMine(new Point(i + 1, j + 1)))
                    {
                        value++;
                    }
                }
            }
            return value;
        }

        private void FillRestPlayground()
        {
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    CreateField(new Point(i, j));
                }
            }
            watch.Stop();
            Console.WriteLine("FillRestPlayground: {0}ms", watch.ElapsedMilliseconds);
        }

        private void CreateField(Point point)
        {
            if (!playground.ContainsKey(point))
            {
                var pole = new Field(point, GetValue(point));
                playground.Add(pole.Point, pole);
            }
        }

        private void LayMinesBackup()
        {
            Stopwatch watch = Stopwatch.StartNew();
            var rnd = new Random();
            var minesList = new List<int>();
            int minePosition;

            for (int i = 0; i < minesCout; i++)
            {
                do
                {
                    minePosition = rnd.Next(0, playgroundSize);
                } while (minesList.Contains(minePosition));
                minesList.Add(minePosition);

                var mine = new Mine(GetCoordinates(minePosition));
                playground.Add(mine.Point, mine);
            }
            watch.Stop();
            Console.WriteLine("LayMines: {0}ms", watch.ElapsedMilliseconds);
        }
        private void LayMines()
        {
            Stopwatch watch = Stopwatch.StartNew();
            var rnd = new Random();
            Point minePosition;

            for (int i = 0; i < minesCout; i++)
            {
                do
                {
                    minePosition = GetCoordinates(rnd.Next(0, playgroundSize));
                } while (playground.ContainsKey(minePosition));

                var mine = new Mine(minePosition);
                playground.Add(mine.Point, mine);
            }
            watch.Stop();
            Console.WriteLine("LayMines: {0}ms", watch.ElapsedMilliseconds);
        }

        private Point GetCoordinates(int minePosition)
        {
            return new Point(minePosition / columns, minePosition % columns);
        }


    }
}