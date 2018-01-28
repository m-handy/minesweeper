using System;

namespace minesweeper
{
    public class Clue : Empty
    {
        private int value;
        private Point point;

        public int Value { get => value; set => this.value = value; }

        public override string Output { get => value.ToString(); }

        public Clue(Point point, int value) : base(point)
        {
            this.point = point;
            this.value = value;
        }

        

    }
}