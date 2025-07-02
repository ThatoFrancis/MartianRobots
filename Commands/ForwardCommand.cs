using MartianRobots.Models;

namespace MartianRobots.Commands
{
    public class ForwardCommand : ICommand
    {
        public void Execute(Position position, Grid grid)
        {
            var next = position.Clone();
            switch (position.Facing)
            {
                case Direction.N: next.Y += 1; break;
                case Direction.E: next.X += 1; break;
                case Direction.S: next.Y -= 1; break;
                case Direction.W: next.X -= 1; break;
            }

            if (grid.IsOffGrid(next.X, next.Y))
            {
                if (!grid.HasScent(position))
                {
                    grid.AddScent(position);
                    throw new InvalidOperationException("Robot is lost");
                }
            }
            else
            {
                position.X = next.X;
                position.Y = next.Y;
            }
        }
    }
}
