namespace minesweeper
{
    public struct Point
    {

        public Point(int v1, int v2)
        {
            this.X = v1;
            this.Y = v2;
        }

        public int X { get; }
        public int Y { get; }
    }
}