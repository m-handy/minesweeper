namespace minesweeper
{
    public struct Point
    {

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override string ToString()
        {
            return "[" + X + "," + Y +"]";
        }
    }
}