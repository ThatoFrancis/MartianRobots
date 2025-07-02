using MartianRobots.Models;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Services
{
    public interface ICommand
    {
        void Execute(Position position, Grid grid);
    }

    public class TurnLeftCommand : ICommand
    {
        public void Execute(Position position, Grid grid)
        {
            position.Facing = position.Facing switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => position.Facing
            };
        }
    }

    public class TurnRightCommand : ICommand
    {
        public void Execute(Position position, Grid grid)
        {
            position.Facing = position.Facing switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => position.Facing
            };
        }
    }

    public class MoveForwardCommand : ICommand
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

    public class RobotService
    {
        private readonly Grid _grid;
        private readonly Dictionary<char, ICommand> _commands;

        public RobotService(Grid grid)
        {
            _grid = grid;
            _commands = new Dictionary<char, ICommand>
            {
                { 'L', new TurnLeftCommand() },
                { 'R', new TurnRightCommand() },
                { 'F', new MoveForwardCommand() }
            };
        }

        public string Execute(Position start, string instructions)
        {
            var position = start;
            bool isLost = false;

            foreach (var instruction in instructions)
            {
                try
                {
                    if (_commands.ContainsKey(instruction))
                    {
                        _commands[instruction].Execute(position, _grid);
                    }
                }
                catch (InvalidOperationException)
                {
                    isLost = true;
                    break;
                }
            }

            var result = new StringBuilder($"{position.X} {position.Y} {position.Facing}");
            if (isLost) result.Append(" LOST");
            return result.ToString();
        }
    }
}
