using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace minesweeper
{
    public class Playground
    {
        private int rows;
        private int columns;
        private int minesCout;
        private int playgroundSize;
        private ConcurrentDictionary<Point, Mine> mines = new ConcurrentDictionary<Point, Mine>();
        private ConcurrentDictionary<Point, Clue> minesNeighbors = new ConcurrentDictionary<Point, Clue>();
        public ConcurrentDictionary<Point, Mine> Mines { get => mines; }

        public Playground(int rows, int columns, int minesCount)
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

            LayMines();
            //GetValuesOfNeighbors();
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

        private int GetValue(Point point)
        {
            var neighbours = GetNeighborsList(point, true);
            var value = 0;
            foreach (var field in neighbours)
            {
                if (IsMine(field))
                {
                    value++;
                }
            }
            return value;
        }

        private void GetValuesOfNeighbors()
        {
            Stopwatch watch = Stopwatch.StartNew();
            Parallel.For(0, rows, i =>
                {
                    for (int j = 0; j < columns; j++)
                    {
                        var point = new Point(i, j);
                        if (!IsMine(point) && IsNeighbor(point))
                        {
                            minesNeighbors[point].Value = GetValue(point);
                        }
                    }
                });
            watch.Stop();
            Console.WriteLine("GetValuesOfNeighbors: {0}ms", watch.ElapsedMilliseconds);
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
                } while (mines.ContainsKey(minePosition));

                var mine = new Mine(minePosition);
                mines.TryAdd(mine.Point, mine);
                minesNeighbors.TryRemove(mine.Point, out _);
                AddOrUpdateNeighbors(mine.Point);
            }

            watch.Stop();
            Console.WriteLine("LayMines: {0}ms", watch.ElapsedMilliseconds);
        }

        private Point GetCoordinates(int minePosition)
        {
            return new Point(minePosition / columns, minePosition % columns);
        }

        private void AddOrUpdateNeighbors(Point point)
        {
            foreach (var neighborPoint in GetNeighborsList(point, false))
            {
                minesNeighbors.AddOrUpdate(neighborPoint, new Clue(neighborPoint, 1), (key, oldClue) =>
                {
                    oldClue.Value++;
                    return oldClue;
                });
            }
        }

        private List<Point> GetNeighborsList(Point point, bool isMine)
        {
            return GetNeighborsList(point.X, point.Y, isMine);
        }
        private List<Point> GetNeighborsList(int i, int j, bool isMine)
        {
            var neighbors = new List<Point>();
            Point tmp;

            if (i > 0)
            {
                if (j > 0)
                {
                    if (isMine == IsMine(tmp = new Point(i - 1, j - 1)))
                    {
                        neighbors.Add(tmp);
                    }
                }
                if (isMine == IsMine(tmp = new Point(i - 1, j)))
                {
                    neighbors.Add(tmp);
                }
                if (j < columns - 1)
                {
                    if (isMine == IsMine(tmp = new Point(i - 1, j + 1)))
                    {
                        neighbors.Add(tmp);
                    }
                }
            }

            if (j > 0)
            {
                if (isMine == IsMine(tmp = new Point(i, j - 1)))
                {
                    neighbors.Add(tmp);
                }
            }
            if (j < columns - 1)
            {
                if (isMine == IsMine(tmp = new Point(i, j + 1)))
                {
                    neighbors.Add(tmp);
                }
            }

            if (i < rows - 1)
            {
                if (j > 0)
                {
                    if (isMine == IsMine(tmp = new Point(i + 1, j - 1)))
                    {
                        neighbors.Add(tmp);
                    }
                }
                if (isMine == IsMine(tmp = new Point(i + 1, j)))
                {
                    neighbors.Add(tmp);
                }
                if (j < columns - 1)
                {
                    if (isMine == IsMine(tmp = new Point(i + 1, j + 1)))
                    {
                        neighbors.Add(tmp);
                    }
                }
            }

            return neighbors;
        }
    }
}