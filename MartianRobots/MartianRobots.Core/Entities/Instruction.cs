namespace MartianRobots.Core.Entities
{
    public enum Instruction
    {
        Left,
        Right,
        Forward
    }

    public static class InstructionExtensions
    {
        public static (Instruction? instruction, string error) ParseInstruction(char c)
        {
            switch (c)
            {
                case 'L':
                    return (Instruction.Left, "");
                case 'R':
                    return (Instruction.Right, "");
                case 'F':
                    return (Instruction.Forward, "");
                default:
                    return (null, $"Invalid instruction character {c}");
            }
        }
    }
}
