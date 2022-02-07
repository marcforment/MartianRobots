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
        public string ExploreWorld(ExploreRequest exploreRequest)
        {
            foreach (Robot robot in exploreRequest.Robots)
            {
               ExecuteRobotInstructions(exploreRequest.World, robot);
            }
            return BuildResultString(exploreRequest.Robots);
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
            for (int i = 0; i < robots.Count; i++)
            {
                var robot = robots[i];
                sb.Append(robot.ResultString());
                if(i < robots.Count - 1)
                {
                    sb.Append("\n");
                }
            }
            return sb.ToString();
        }
    }
}