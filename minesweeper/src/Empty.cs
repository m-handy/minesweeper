using System;

namespace minesweeper
{
    public class Empty
    {
        private Point point;
        public Point Point { get => point; }

        public virtual string Output { get => " "; }

        public Empty(Point point)
        {
            this.point = point;
        }

    }
}