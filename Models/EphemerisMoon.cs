using System.Text.Json.Serialization;

namespace OurSolarSystemAPI.Models
{
    public class EphemerisMoon
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int MoonId { get; set; }
        [JsonIgnore]
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
                PositionX = Convert.ToDouble(ephemerisDict["positionX"]),
                PositionY = Convert.ToDouble(ephemerisDict["positionY"]),
                PositionZ = Convert.ToDouble(ephemerisDict["positionZ"]),
                VelocityX = Convert.ToDouble(ephemerisDict["velocityX"]),
                VelocityY = Convert.ToDouble(ephemerisDict["velocityY"]),
                VelocityZ = Convert.ToDouble(ephemerisDict["velocityZ"]),
                DateTime = (DateTime) ephemerisDict["dateTime"],
                JulianDate = Convert.ToDouble(ephemerisDict["julianDate"])
            };
        }
    }

}