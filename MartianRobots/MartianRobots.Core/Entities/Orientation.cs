namespace MartianRobots.Core.Entities
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
       
        public static (Orientation? orientation, string error) ParseOrientation(string orientation)
        {
            switch(orientation)
            {
                case "N":
                    return (Orientation.North,"");
                case "S":
                    return (Orientation.South,"");
                case "W":
                    return (Orientation.West,"");
                case "E":
                    return (Orientation.East,"");
                default:
                    return (null, $"Invalid orientation string {orientation}");
            }
        }
    }
}
