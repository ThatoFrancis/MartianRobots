using MartianRobots.Commands;
using MartianRobots.Models;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Services
{
    public class RobotService
    {
        private readonly Grid _grid;
        private readonly Dictionary<char, ICommand> _commands;

        public RobotService(Grid grid)
        {
            _grid = grid;
            _commands = new Dictionary<char, ICommand>
            {
                { 'L', new LeftCommand() },
                { 'R', new RightCommand() },
                { 'F', new ForwardCommand() }
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
