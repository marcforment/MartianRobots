namespace MartianRobots.Entities
{
    public enum Orientation
    {
        North,
        South,
        West,
        East
    }

    public static class OrientationExtensions
    {
        public static string ResultString(this Orientation o)
        {
            switch (o)
            {
                case Orientation.North:
                    return "N";
                case Orientation.South:
                    return "S";
                case Orientation.West:
                    return "W";
                default:
                    return "E";
            }
        }
       
    }
}
