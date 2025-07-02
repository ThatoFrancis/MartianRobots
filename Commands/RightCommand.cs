using MartianRobots.Models;

namespace MartianRobots.Commands
{
    public class RightCommand : ICommand
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
}
