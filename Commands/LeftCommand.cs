using MartianRobots.Models;

namespace MartianRobots.Commands
{
    public class LeftCommand : ICommand
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
}
