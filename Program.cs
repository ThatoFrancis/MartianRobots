using System;
using MartianRobots.Models;
using MartianRobots.Services;

class Program
{
    static void Main()
    {
        // Sample Input from the Coding Challenge Document
        var grid = new Grid(5, 3);
        var service = new RobotService(grid);

        RunRobot(service, new Position(1, 1, Direction.E), "RFRFRFRF");
        RunRobot(service, new Position(3, 2, Direction.N), "FRRFLLFFRRFLL");
        RunRobot(service, new Position(0, 3, Direction.W), "LLFFFLFLFL");
    }

    static void RunRobot(RobotService service, Position start, string instructions)
    {
        try
        {
            var result = service.Execute(start, instructions);
            Console.WriteLine(result);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
