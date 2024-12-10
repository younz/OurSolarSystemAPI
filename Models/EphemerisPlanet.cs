using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace OurSolarSystemAPI.Models
{
    public class EphemerisPlanet
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        [JsonIgnore]
        public Planet Planet { get; set; }
        public double PositionX { get; set; }
        [NotMapped]
        public double ScaledPositionX { get; set; }
         [NotMapped]
        public double ScaledPositionY { get; set; }
         [NotMapped]
        public double ScaledPositionZ { get; set; }
        public double PositionY { get; set; }
        public double PositionZ { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
        public double VelocityZ { get; set; }
        public DateTime DateTime { get; set; }
        public double JulianDate { get; set; }

        public static EphemerisPlanet convertEphemerisDictToObject(Dictionary<string, object> ephemerisDict, Planet planet)
        {
            return new EphemerisPlanet 
            {
                Planet = planet,
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
