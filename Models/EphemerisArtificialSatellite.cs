using SGPdotNET.Observation;

namespace OurSolarSystemAPI.Models
{
    public class EphemerisArtificialSatellite
    {
        public int Id { get; set; }
        public int SatelitteId { get; set; }
        public ArtificialSatellite Satellite { get; set; }
        public required double PositionX { get; set; }
        public required double PositionZ { get; set; }
        public required double PositionY { get; set; }
        public required double VelocityX { get; set; }
        public required double VelocityY { get; set; }
        public required double VelocityZ { get; set; }
        public required string Epoch { get; set; }
        public required DateTime DateTime { get; set; }

        // public static EphemerisArtificialSatellite convertEphemerisDictToObject(Dictionary<string, object> ephemerisDict, ArtificialSatellite satellite)
        // {
        //     return new EphemerisArtificialSatellite 
        //     {
        //         Satellite = satellite,
        //         PositionX = (double) ephemerisDict["positionX"],
        //         PositionY = (double) ephemerisDict["positionY"],
        //         PositionZ = (double) ephemerisDict["positionZ"],
        //         VelocityX = (double) ephemerisDict["velocityX"],
        //         VelocityY = (double) ephemerisDict["velocityY"],
        //         VelocityZ = (double) ephemerisDict["velocityZ"],
        //         DateTime = (DateTime) ephemerisDict["dateTime"],
        //     };
        // }

    }
}