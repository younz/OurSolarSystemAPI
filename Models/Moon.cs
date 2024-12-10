using System.Text.Json.Serialization;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OurSolarSystemAPI.Models
{
    public class Moon
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int PlanetId { get; set; }
        [JsonIgnore]
        [NotMapped]
        public int HorizonPlanetId { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string? PlanetName { get; set; }
        [JsonIgnore]
        public int HorizonId { get; set; }
        [JsonIgnore]
        public Planet Planet { get; set; }
        [JsonIgnore]
        public List<EphemerisMoon>? Ephemeris { get; set; }
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
