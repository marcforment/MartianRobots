using MartianRobots.Entities;
using System.Text;

namespace MartianRobots.Core
{
    public class ExploreLogic
    {
        public string ExploreWorld(World world, List<Robot> robots)
        {
            foreach (Robot robot in robots)
            {
                foreach(Instruction instruction in robot.Instructions)
                {
                    var newPosition = robot.Position.executeInstruction(instruction, world.Smells);
                    if(world.isOutside(newPosition))
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
            return "Not yet";
        }

        private string toResultString(this List<Robot> robots)
        {
            var sb = new StringBuilder();
            robots.ForEach(robot =>
                sb.AppendLine(robot.ResultString())
            );
            return sb.ToString();
        }
    }
}