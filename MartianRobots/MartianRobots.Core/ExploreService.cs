using MartianRobots.Core.Entities;
using System.Text;

namespace MartianRobots.Core
{
    public class ExploreService : IExploreService
    {
        private readonly ITopScoreRepository _topScoreService;
        
        public ExploreService(ITopScoreRepository topScoreService)
        {
            _topScoreService = topScoreService;
        }
        public string ExploreWorld(World world, List<Robot> robots)
        {
            foreach (Robot robot in robots)
            {
               ExecuteRobotInstructions(world, robot);
            }
            return BuildResultString(robots);
        }

        private void ExecuteRobotInstructions(World world, Robot robot)
        {
            foreach (Instruction instruction in robot.Instructions)
            {
                var newPosition = robot.Position.executeInstruction(instruction);
                if (world.IsOutside(newPosition))
                {
                    if (!world.Smells.Contains(newPosition.Coordinate))
                    {
                        robot.IsLost = true;
                        world.Smells.Add(robot.Position.Coordinate);
                        break;
                    }
                }
                else
                {
                    robot.Position = newPosition;
                }
            }
        }
        private string BuildResultString(List<Robot> robots)
        {
            var sb = new StringBuilder();
            foreach (Robot robot in robots)
            {
                sb.AppendLine(robot.ResultString());
            }
            return sb.ToString();
        }
    }
}