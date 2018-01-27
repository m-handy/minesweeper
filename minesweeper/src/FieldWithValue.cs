using System;

namespace minesweeper
{
    public class FieldWithValue : EmptyField
    {
        private int value;
        private Point point;

        public int Value { get => value; set => this.value = value; }

        public override string Output { get => value.ToString(); }

        public FieldWithValue(Point point, int value) : base(point)
        {
            this.point = point;
            this.value = value;
        }

        

    }
}