namespace OurSolarSystemAPI.Models
{
    public class EphemerisMoon
    {
        public int Id { get; set; }
        public int MoonId { get; set; }
        public required Moon Moon { get; set; }
        public required double PositionX { get; set; }
        public required double PositionY { get; set; }
        public required double PositionZ { get; set; }
        public required double VelocityX { get; set; }
        public required double VelocityY { get; set; }
        public required double VelocityZ { get; set; }
        public required double JulianDate { get; set; }
        public required DateTime DateTime { get; set; }

        public static EphemerisMoon convertEphemerisDictToObject(Dictionary<string, object> ephemerisDict, Moon moon)
        {
            return new EphemerisMoon 
            {
                Moon = moon,
                PositionX = (double) ephemerisDict["positionX"],
                PositionY = (double) ephemerisDict["positionY"],
                PositionZ = (double) ephemerisDict["positionZ"],
                VelocityX = (double) ephemerisDict["velocityX"],
                VelocityY = (double) ephemerisDict["velocityY"],
                VelocityZ = (double) ephemerisDict["velocityZ"],
                DateTime = (DateTime) ephemerisDict["dateTime"],
                JulianDate = (double) ephemerisDict["julianDate"]
            };
        }
    }

}