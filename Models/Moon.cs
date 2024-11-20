using System.Collections.Generic;

namespace OurSolarSystemAPI.Models
{
    public class Moon
    {
        public int Id { get; set; }
        public int PlanetId { get; set; }
        public ICollection<EphemerisMoon>? Ephemeris { get; set; }
        public required string Name { get; set; }
        public string? MeanRadius { get; set; }
        public string? Density { get; set; }
        public string? Gm { get; set; }
        public string? SemiMajorAxis { get; set; }
        public string? GravitationalParameter { get; set; }
        public string? GeometricAlbedo { get; set; }
        public string? OrbitalPeriod { get; set; }
        public string? Eccentricity { get; set; }
        public string? RotationalPeriod { get; set; }
        public string? Inclination { get; set; }
    }


}
