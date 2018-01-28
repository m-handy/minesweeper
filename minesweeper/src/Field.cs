using System;
using System.Diagnostics;
using System.Collections.Generic;
using Minesweeper.Fields;

namespace Minesweeper
{
    public class Field
    {
        private int rows;
        private int columns;
        private int minesCout;
        private int playgroundSize;
        private Dictionary<Point, Mine> mines = new Dictionary<Point, Mine>();
        private Dictionary<Point, Clue> minesNeighbors = new Dictionary<Point, Clue>();
    
        public int Rows { get => rows; }
        public int Columns { get => columns; }
        public Dictionary<Point, Mine> Mines { get => mines; }
        public Dictionary<Point, Clue> MinesNeighbors { get => minesNeighbors; }

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
                } while (minePosition.IsMine(this));

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
            Point neighbor;

            if (i > 0)
            {
                if (j > 0)
                {
                    neighbor = new Point(i - 1, j - 1);
                    if (!neighbor.IsMine(this))
                    {
                        neighbors.Add(neighbor);
                    }
                }
                neighbor = new Point(i - 1, j);
                if (!neighbor.IsMine(this))
                {
                    neighbors.Add(neighbor);
                }
                if (j < columns - 1)
                {
                    neighbor = new Point(i - 1, j + 1);
                    if (!neighbor.IsMine(this))
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }

            if (j > 0)
            {
                neighbor = new Point(i, j - 1);
                if (!neighbor.IsMine(this))
                {
                    neighbors.Add(neighbor);
                }
            }
            if (j < columns - 1)
            {
                neighbor = new Point(i, j + 1);
                if (!neighbor.IsMine(this))
                {
                    neighbors.Add(neighbor);
                }
            }

            if (i < rows - 1)
            {
                if (j > 0)
                {
                    neighbor = new Point(i + 1, j - 1);
                    if (!neighbor.IsMine(this))
                    {
                        neighbors.Add(neighbor);
                    }
                }
                neighbor = new Point(i + 1, j);
                if (!neighbor.IsMine(this))
                {
                    neighbors.Add(neighbor);
                }
                if (j < columns - 1)
                {
                    neighbor = new Point(i + 1, j + 1);
                    if (!neighbor.IsMine(this))
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }

            return neighbors;
        }
    }
}