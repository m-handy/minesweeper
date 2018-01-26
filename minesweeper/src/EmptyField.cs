using System;

namespace minesweeper
{
    public class EmptyField
    {
        private Point point;
        public Point Point { get => point; }

        public virtual string Output { get => " "; }

        public EmptyField(Point point)
        {
            this.point = point;
        }



    }
}