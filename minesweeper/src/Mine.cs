using System;

namespace minesweeper
{
    public class Mine : Field
    {
        public Mine(Point point): base(point, -1)
        {
        }

        internal override string Print(){
            return "X";
        }
    }
}