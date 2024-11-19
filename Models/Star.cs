namespace OurSolarSystemAPI.Models
{
    public class Star
    {
        public int Id { get; set; } //primary key
        public string gravitational_parameter { get; set; }

        public string mass { get; set; }

        public string volume_mean_radius { get; set; }

        public string volume { get; set; }

        public string solar_radius { get; set; }
        public string radius { get; set; }

        public string angular_diameter { get; set; }

        public string photosphere_temperature { get; set; }

        public string photospheric_depth { get; set; }

        public string chromospheric_depth { get; set; }

        public string flatness { get; set; }

        public string surface_gravity { get; set; }

        public string escape_speed { get; set; }

        public string right_ascension { get; set; }

        public string declination { get; set; }

        public string obliquity_to_ecliptic { get; set; }

        public string solar_constant_one_au { get; set; }

        public string luminosity { get; set; }

        public string mass_energy_conversion_rate { get; set; }

        public string effective_temperature { get; set; }

        public string sunspot_cycle { get; set; }

        public string cycle_24_sunspot_minimum { get; set; }
        //foreign key
        public int barrycenterID { get; set; }
    }
}
