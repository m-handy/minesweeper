using System;

namespace minesweeper{
    public class Field{
        private int value;
        private Point point;
        public Point Point { get => point;}

        public Field(Point point, int value)
        {
            this.point = point;
            this.value = value;
        }
        
        internal virtual string Print()
        {
            return "" + this.value + "";
        }
    }
}