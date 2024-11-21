using System.Numerics;

namespace OurSolarSystemAPI.Models
{
    public class ArtificialSatellite
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }
        public EphemerisArtificialSatellite? Ephemeris { get; set; }
        public string? LaunchDate { get; set; }
        public string? LaunchSite { get; set; }
        public string? BStarDragTerm { get; set; }
        public string? Eccentricity { get; set; }
        public string? MeanAnomaly { get; set; }
        public string? OrbitNumber { get; set; }
        public string? Source { get; set; }
        public string? NoradId { get; set; }
        public string? NssdcId { get; set; }
        public string? Perigee { get; set; }
        public string? Apogee { get; set; }
        public string? Inclination { get; set; }
        public string? Period { get; set; }
        public string? SemiMajorAxis { get; set; }
        public string? Rcs { get; set; }
        public required string Name { get; set; }
    }

}
