using MartianRobots.Core.Entities;
using System.Text.RegularExpressions;

namespace MartianRobots.Web.Contract.V1
{
    public class TranslatorV1
    {
        public static (ExploreRequest? result, string error) TranslateToCoreRequest(ExploreRequestV1 requestV1)
        {
            var lines = Regex.Split(requestV1.Input, "\r\n|\r|\n");
            if (lines == null || lines.Length == 0)
            {
                return (null, "Input field cannot be empty.");
            }

            if (lines.Length == 1 || lines.Length % 2 == 0)
            {
                return (null, "Incorrect number of lines. Input needs to contain at least a line with world bonduary definition and two lines with a robot definition.");
            }

            var (world, worldError) = ParseWorld(lines[0]);
            if (world == null)
            {
                return (null, worldError);
            }

            var robots = new List<Robot>();
            for (int i = 1; i < lines.Length; i += 2)
            {
                var positionString = lines[i];
                var instructionsString = lines[i + 1];

                var (position, positionError) = ParsePosition(positionString, world);
                var (instructions, instructionsError) = ParseInstructions(instructionsString);
                if(position == null)
                {
                    return (null, positionError);
                }
                if(instructions == null)
                {
                    return (null, instructionsError);
                }
                robots.Add(new Robot(position, instructions));
            }

            return (new ExploreRequest(world, robots), "");
        }

        private static (World? world, string error) ParseWorld(string worldLine)
        {
            var numberStrings = worldLine.Trim().Split(" ");

            var (coordinate, error) = ParseCoordinate(numberStrings[0], numberStrings[1]);
            if(coordinate == null)
            {
                return (null, error);
            }
            else 
            {
                return (new World(coordinate),"");
            }
        }

        private static (Position? position, string error) ParsePosition(string positionLine, World world)
        {
            var positionStrings = positionLine.Trim().Split(" ");

            var (coordinate, coordinateError) = ParseCoordinate(positionStrings[0], positionStrings[1]);
            if(coordinate == null)
            {
                return (null, coordinateError);
            }
            else if(coordinate.X > world.Edge.X || coordinate.Y > world.Edge.Y)
            {
                return (null, $"Robot position {coordinate.X} {coordinate.Y} needs to be inside bonduary {world.Edge.X} {world.Edge.Y}");
            }

            var (orientation, orientetionError) = OrientationExtensions.ParseOrientation(positionStrings[2]);
            if(orientation == null)
            {
                return (null, orientetionError);
            }
            
            return (new Position(coordinate, (Orientation)orientation), "");
            
        }

        private static (Coordinate? coordinate, string error) ParseCoordinate(string xString, string yString)
        {
            int x, y;

            try
            {
                x = int.Parse(xString);
                y = int.Parse(yString);
            }
            catch (Exception e)
            {
                return (null, $"There was a problem parsing cooordinates: {xString} {yString}");
            }

            if (x < 0 || y < 0 || x > 50 || y > 50)
            {
                return (null, $"Coordinates: {xString} {yString} need to be positive and less than or equal than 50");
            }

            return (new Coordinate(x, y), "");
        }

        private static (List<Instruction>? instruction, string error) ParseInstructions(string instructionsString)
        {
            if(instructionsString.Length >= 100)
            {
                return (null, "Instruction strings need to be leess than 100 characters in length");
            }
            var instructions = new List<Instruction>();
            var instructionChars = instructionsString.ToCharArray();
            foreach(var instructionChar in instructionChars)
            {
                var (instruction, instructionError) = InstructionExtensions.ParseInstruction(instructionChar);
                if(instruction == null)
                {
                    return (null, instructionError);
                }
                else
                {
                    instructions.Add((Instruction)instruction);
                }
            }

            return (instructions, "");
        }
    }
}
