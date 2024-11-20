using System.Numerics;

namespace OurSolarSystemAPI.Models
{
    public class ArtificialSatellite
    {
        // Properties of the class
        public int Id { get; set; }
        public required int PlanetId { get; set; }
        public required Planet Planet { get; set; }
        public EphemerisArtificialSatellite? Ephemeris { get; set; }
        public int? LaunchDateDay { get; set; }
        public int? LaunchDateMonth { get; set; }
        public int? LaunchDateYear { get; set; }
        public int? LaunchSite { get; set; }
        public int? Source { get; set; }
        public int? NoradId { get; set; }
        public string? NssdcId { get; set; }
        public int? Perigee { get; set; }
        public int? Apogee { get; set; }
        public int? Inclination { get; set; }
        public int? Period { get; set; }
        public int? SemiMajorAxis { get; set; }
        public int? Rcs { get; set; }
        public required string Name { get; set; }
    }

}
