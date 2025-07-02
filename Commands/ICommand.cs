using MartianRobots.Models;

namespace MartianRobots.Commands
{
    public interface ICommand
    {
        void Execute(Position position, Grid grid);
    }
}
