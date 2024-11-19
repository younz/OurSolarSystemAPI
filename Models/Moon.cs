namespace OurSolarSystemAPI.Models
{
    public class Moon
    {
        private int id { get; set; }
        private string name { get; set; }
        private string meanRadius { get; set; }
        private string density { get; set; }
        private string gravitationalParameter { get; set; }
        private string geometricAlbedo { get; set; }
        private int planetId { get; set; } // foreign key

        public Moon(
            int id,
            string name,
            string meanRadius,
            string density,
            string gravitationalParameter,
            string geometricAlbedo,
            int planetId)
        {
            this.id = id;
            this.name = name;
            this.meanRadius = meanRadius;
            this.density = density;
            this.gravitationalParameter = gravitationalParameter;
            this.geometricAlbedo = geometricAlbedo;
            this.planetId = planetId;
        }
    }

}
