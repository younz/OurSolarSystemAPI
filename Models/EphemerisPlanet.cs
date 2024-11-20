namespace OurSolarSystemAPI.Models
{
    public class EphemerisPlanet
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public required Planet Planet { get; set; }
        public required double PositionX { get; set; }
        public required double PositionY { get; set; }
        public required double PositionZ { get; set; }
        public required double VelocityX { get; set; }
        public required double VelocityY { get; set; }
        public required double VelocityZ { get; set; }
        public required DateTime DateTime { get; set; }
        public required double JulianDate { get; set; }

        public static EphemerisPlanet convertEphemerisDictToObject(Dictionary<string, object> ephemerisDict, Planet planet)
        {
            return new EphemerisPlanet 
            {
                Planet = planet,
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
