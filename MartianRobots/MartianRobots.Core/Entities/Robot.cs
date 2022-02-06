namespace MartianRobots.Core.Entities
{
    public class Robot
    {
        public Position Position { get; set; }
        public List<Instruction> Instructions { get; set; }
        public bool IsLost { get; set; }
        private string LostResultString => IsLost ? " LOST" : "";

        public Robot(Position position, List<Instruction> instructions)
        {
            Position = position;
            Instructions = instructions;
            IsLost = false;
        }

        public string ResultString()
        {
            return $"{Position.ResultString()}{LostResultString}";
        }
    }
}
