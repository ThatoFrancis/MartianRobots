using MartianRobots.Models;
using MartianRobots.Services;
using Xunit;

namespace MartianRobots.Tests
{
    public class RobotServiceTests
    {
        [Fact]
        public void RobotCompletesInstructionsWithoutFalling()
        {
            var grid = new Grid(5, 3);
            var robotService = new RobotService(grid);
            var start = new Position(1, 1, Direction.E);
            var result = robotService.Execute(start, "RFRFRFRF");

            Assert.Equal("1 1 E", result);
        }

        [Fact]
        public void RobotGetsLostAndLeavesScent()
        {
            var grid = new Grid(5, 3);
            var robotService = new RobotService(grid);
            var result1 = robotService.Execute(new Position(3, 2, Direction.N), "FRRFLLFFRRFLL");

            Assert.Equal("3 3 N LOST", result1);
        }

        [Fact]
        public void RobotAvoidsFallingDueToScent()
        {
            var grid = new Grid(5, 3);
            var robotService = new RobotService(grid);
            robotService.Execute(new Position(3, 2, Direction.N), "FRRFLLFFRRFLL"); // Leaves scent

            var result2 = robotService.Execute(new Position(0, 3, Direction.W), "LLFFFLFLFL");
            Assert.Equal("2 3 S", result2);
        }
    }
}
