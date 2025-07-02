using System.Collections.Generic;

namespace MartianRobots.Models
{
    public class Grid
    {
        public int MaxX { get; }
        public int MaxY { get; }
        private readonly HashSet<(int, int, Direction)> scents = new();

        public Grid(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsOffGrid(int x, int y) => x < 0 || y < 0 || x > MaxX || y > MaxY;

        public void AddScent(Position pos) => scents.Add((pos.X, pos.Y, pos.Facing));

        public bool HasScent(Position pos) => scents.Contains((pos.X, pos.Y, pos.Facing));
    }
}