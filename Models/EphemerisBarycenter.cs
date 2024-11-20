using Google.Protobuf.WellKnownTypes;

namespace OurSolarSystemAPI.Models
{
    public class EphemerisBarycenter
    {
        public int Id { get; set; }
        public int BarycenterId { get; set; }
        public Barycenter? Barycenter { get; set; } 
        public required double PositionX { get; set; }
        public required double PositionZ { get; set; }
        public required double PositionY { get; set; }
        public required double VelocityX { get; set; }
        public required double VelocityY { get; set; }
        public required double VelocityZ { get; set; }
        public DateTime DateTime { get; set; }

        public double JulianDate { get; set; }

        public static EphemerisBarycenter convertEphemerisDictToObject(Dictionary<string, object> ephemerisDict, Barycenter barycenter)
        {
            return new EphemerisBarycenter 
            {
                Barycenter = barycenter,
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