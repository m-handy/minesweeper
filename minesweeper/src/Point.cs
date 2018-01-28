namespace Minesweeper
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

        public bool IsMine(Field field)
        {
            return field.Mines.ContainsKey(this);
        }

        public bool IsNeighbor(Field field)
        {
            return field.MinesNeighbors.ContainsKey(this);
        }

        public override string ToString()
        {
            return "[" + X + "," + Y +"]";
        }
    }
}