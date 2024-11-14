namespace OurSolarSystemAPI.Models
{
    public class SatelliteManMade
    {
        public int PlanetID { get; set; } // foreign key
        public int Launchdate_day { get; set; }
        public int Launchdate_month { get; set; }
        public int Launchdate_year { get; set; }
        public int Launch_site { get; set; }
        public int source { get; set; }
        public int norad_id { get; set; }
        public string nssdc_id { get; set; }
        public int perigee { get; set; }
        public int apogee { get; set; }
        public int inclination { get; set; }
        public int period { get; set; }
        public int semi_major_axis { get; set; }
        public int rcs { get; set; }
        public string Name { get; set; }
    }
}
