namespace GreedySnake
{
    public struct Position
    {
        public Position(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }

        public static bool operator ==(Position a, Position b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Position a, Position b)
        {
            return !(a.X == b.X && a.Y == b.Y);
        }
        public override bool Equals(object obj)
        {
            if (obj is Position pos)
            {
                return this == pos;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }
    }
}
