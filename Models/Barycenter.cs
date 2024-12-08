using System.Text.Json.Serialization;

namespace OurSolarSystemAPI.Models
{
    public class Barycenter()
    {
        public int Id { get; set; }
        public required int HorizonId { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public ICollection<EphemerisBarycenter>? Ephemeris { get; set; }
    }
}
