namespace OurSolarSystemAPI.Models
{
    public class Moon
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string MeanRadius { get; set; }
        public string density { get; set; }
        public string gravitational_parameter { get; set; }
        public string geometric_albedo { get; set; }
        // foreign key
        public int PlanetId { get; set; }
        
    }
}
