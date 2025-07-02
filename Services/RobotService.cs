using MartianRobots.Models;
using System.Text;

namespace MartianRobots.Services
{
    public class RobotService
    {
        private readonly Grid _grid;

        public RobotService(Grid grid)
        {
            _grid = grid;
        }

        public string Execute(Position start, string instructions)
        {
            var position = start;
            bool isLost = false;

            foreach (var instruction in instructions)
            {
                if (instruction == 'L')
                    TurnLeft(position);
                else if (instruction == 'R')
                    TurnRight(position);
                else if (instruction == 'F')
                {
                    var next = GetNextPosition(position);
                    if (_grid.IsOffGrid(next.X, next.Y))
                    {
                        if (_grid.HasScent(position))
                            continue;
                        isLost = true;
                        _grid.AddScent(position);
                        break;
                    }
                    position = next;
                }
            }

            var result = new StringBuilder($"{position.X} {position.Y} {position.Facing}");
            if (isLost) result.Append(" LOST");
            return result.ToString();
        }

        private void TurnLeft(Position pos)
        {
            pos.Facing = pos.Facing switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => pos.Facing
            };
        }

        private void TurnRight(Position pos)
        {
            pos.Facing = pos.Facing switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => pos.Facing
            };
        }

        private Position GetNextPosition(Position pos)
        {
            var next = pos.Clone();
            switch (pos.Facing)
            {
                case Direction.N: next.Y += 1; break;
                case Direction.E: next.X += 1; break;
                case Direction.S: next.Y -= 1; break;
                case Direction.W: next.X -= 1; break;
            }
            return next;
        }
    }
}
