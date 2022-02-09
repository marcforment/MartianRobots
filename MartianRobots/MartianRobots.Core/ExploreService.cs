using MartianRobots.Core.Entities;
using System.Text;

namespace MartianRobots.Core
{
    public class ExploreService : IExploreService
    {
        private readonly ITopScoreRepository _topScoreService;
        private List<Coordinate> exploredCoordinates;

        public ExploreService(ITopScoreRepository topScoreService)
        {
            _topScoreService = topScoreService;
            exploredCoordinates = new List<Coordinate>();
        }
        public ExploreResponse ExploreWorld(ExploreRequest exploreRequest)
        {
            foreach (Robot robot in exploreRequest.Robots)
            {
               ExecuteRobotInstructions(exploreRequest.World, robot);
            }
            var previousTopScore = _topScoreService.GetTopScore();
            var savedScore = CalculateAndSaveScore();
            return new ExploreResponse(BuildResultString(exploreRequest.Robots), savedScore, previousTopScore);
        }

        private void ExecuteRobotInstructions(World world, Robot robot)
        {
            exploredCoordinates.Add(robot.Position.Coordinate);
            foreach (Instruction instruction in robot.Instructions)
            {
                var newPosition = robot.Position.executeInstruction(instruction);
                if (world.IsOutside(newPosition))
                {
                    if (!world.Smells.Any(c => c.X == robot.Position.Coordinate.X && c.Y == robot.Position.Coordinate.Y))
                    {
                        robot.IsLost = true;
                        world.Smells.Add(robot.Position.Coordinate);
                        break;
                    }
                }
                else
                {
                    robot.Position = newPosition;
                    if(instruction == Instruction.Forward)
                    {
                        exploredCoordinates.Add(robot.Position.Coordinate);
                    }
                }
            }
        }

        private int CalculateAndSaveScore()
        {
            var score = CalculateScore();

            _topScoreService.SaveScore(score);

            return score;
        }

        private int CalculateScore()
        {
            var coordinateGroups = exploredCoordinates.GroupBy(
                coordinate => (coordinate.X * 10) + coordinate.Y,
                (value, repetition) => new
                {
                    value = value,
                    ineficiency = repetition.Count() - 1
                }
            );
            var score = coordinateGroups.Count() - coordinateGroups.Sum(i => i.ineficiency);

            return score;
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