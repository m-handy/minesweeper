using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace minesweeper
{
    public class Field
    {
        private int rows;
        private int columns;
        private int minesCout;
        private int playgroundSize;
        private Dictionary<Point, Mine> mines = new Dictionary<Point, Mine>();
        private Dictionary<Point, Clue> minesNeighbors = new Dictionary<Point, Clue>();
        public Dictionary<Point, Mine> Mines { get => mines; }

        public Field(int rows, int columns, int minesCount)
        {
            playgroundSize = rows * columns;
            if (minesCount > playgroundSize)
            {
                throw new ArgumentOutOfRangeException("mines", minesCount, "number of mines cannot be bigger than size of the field!");
            }
            if (rows < 1)
            {
                throw new ArgumentOutOfRangeException("rows", rows, "number of rows cannot be less than one!");
            }
            if (columns < 1)
            {
                throw new ArgumentOutOfRangeException("columns", columns, "number of columns cannot be less than one!");
            }
            if (minesCount < 1)
            {
                throw new ArgumentOutOfRangeException("mines", columns, "number of mines cannot be less than one!");
            }
            this.rows = rows;
            this.columns = columns;
            this.minesCout = minesCount;

            InitField();
        }

        public void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var point = new Point(i, j);
                    Console.BackgroundColor = ConsoleColor.Gray;

                    if (IsMine(point))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(mines[point].Output);
                    }
                    else if (IsNeighbor(point))
                    {
                        switch (minesNeighbors[point].Value)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                        }
                        Console.Write(minesNeighbors[point].Output);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.ResetColor();
                Console.Write(Environment.NewLine);
            }
        }

        private bool IsMine(Point point)
        {
            return mines.ContainsKey(point);
        }

        private bool IsNeighbor(Point point)
        {
            return minesNeighbors.ContainsKey(point);
        }

        private void InitField()
        {
            Stopwatch watch = Stopwatch.StartNew();
            var rnd = new Random();
            Point minePosition;

            for (int i = 0; i < minesCout; i++)
            {
                do
                {
                    minePosition = GetCoordinates(rnd.Next(0, playgroundSize));
                } while (mines.ContainsKey(minePosition));

                var mine = new Mine(minePosition);
                mines.TryAdd(mine.Point, mine);
                minesNeighbors.Remove(mine.Point);
                AddOrUpdateNeighbors(mine.Point);
            }

            watch.Stop();
            Console.WriteLine("InitField: {0}ms", watch.ElapsedMilliseconds);
        }

        private Point GetCoordinates(int minePosition)
        {
            return new Point(minePosition / columns, minePosition % columns);
        }

        private void AddOrUpdateNeighbors(Point point)
        {
            foreach (var neighborPoint in GetNeighborsList(point))
            {
                Clue clue;
                if (minesNeighbors.TryGetValue(neighborPoint, out clue))
                {
                    clue.Value++;
                }
                else
                {
                    minesNeighbors.TryAdd(neighborPoint, new Clue(neighborPoint, 1));
                }
            }           
        }

        private List<Point> GetNeighborsList(Point point)
        {
            return GetNeighborsList(point.X, point.Y);
        }

        private List<Point> GetNeighborsList(int i, int j)
        {
            var neighbors = new List<Point>();
            Point tmp;

            if (i > 0)
            {
                if (j > 0)
                {
                    if (!IsMine(tmp = new Point(i - 1, j - 1)))
                    {
                        neighbors.Add(tmp);
                    }
                }
                if (!IsMine(tmp = new Point(i - 1, j)))
                {
                    neighbors.Add(tmp);
                }
                if (j < columns - 1)
                {
                    if (!IsMine(tmp = new Point(i - 1, j + 1)))
                    {
                        neighbors.Add(tmp);
                    }
                }
            }

            if (j > 0)
            {
                if (!IsMine(tmp = new Point(i, j - 1)))
                {
                    neighbors.Add(tmp);
                }
            }
            if (j < columns - 1)
            {
                if (!IsMine(tmp = new Point(i, j + 1)))
                {
                    neighbors.Add(tmp);
                }
            }

            if (i < rows - 1)
            {
                if (j > 0)
                {
                    if (!IsMine(tmp = new Point(i + 1, j - 1)))
                    {
                        neighbors.Add(tmp);
                    }
                }
                if (!IsMine(tmp = new Point(i + 1, j)))
                {
                    neighbors.Add(tmp);
                }
                if (j < columns - 1)
                {
                    if (!IsMine(tmp = new Point(i + 1, j + 1)))
                    {
                        neighbors.Add(tmp);
                    }
                }
            }

            return neighbors;
        }
    }
}