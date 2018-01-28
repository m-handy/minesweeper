using System;

namespace minesweeper
{
    public class Mine : Empty
    {
        
        public override string Output { get => "X"; }

        public Mine(Point point) : base(point) {}

    }
}