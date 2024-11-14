namespace OurSolarSystemAPI.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string volumeMeanRadius { get; set; }
        public string density { get; set; }
        public string mass { get; set; }
        public string flattening { get; set; }
        public string Volume { get; set; }

        public string equatorial_radius { get; set; }

        public string sidereal_rotation_period { get; set; }

        public string sidereal_rotation_rate { get; set; }

        public string mean_solar_day { get; set; }

        public string polar_gravity { get; set; }

        public string equatorial_gravity { get; set; }

        public string geometric_albedo { get; set; }

        public string mass_ratio_to_sun { get; set; }

        public string mean_temperature { get; set; }

        public string atmospheric_pressure { get; set; }

        public string obliquity_to_orbit { get; set; }

        public string max_angular_diameter { get; set; }

        public string mean_side_real_orbital_period { get; set; }

        public string orbital_speed { get; set; }

        public string hills_sphere_radius { get; set; }

        public string escape_speed { get; set; }

        public string solar_constant { get; set; }

        public string maximum_planetary_ir { get; set; }

        public string minimum_planetary_ir { get; set; }

        public string gravitational_parameter { get; set; }
        // foreignId 
        public int BarrycenterId { get; set; }

    }
}
