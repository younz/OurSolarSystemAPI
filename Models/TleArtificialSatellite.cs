namespace OurSolarSystemAPI.Models
{
    public class TleArtificialSatellite() 
    {
        public int TleArtificialSatelliteId { get; set; }
        public int ArtificialSatelliteId { get; set; }
        public ArtificialSatellite artificialSatellite { get; set; }
        public string Tle { get; set; }
        public DateTime ScrapedAt { get; set; } 

        public bool IsArchived { get; set; }
    }

}