namespace MartianRobots.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Facing { get; set; }

        public Position(int x, int y, Direction facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public Position Clone() => new Position(X, Y, Facing);
    }
}