using System;

namespace minesweeper
{
    public class Mine : EmptyField
    {
        
        public override string Output { get => "X"; }

        public Mine(Point point) : base(point) {}

    }
}