namespace OurSolarSystemAPI.Models
{
    public class Star
    {
        public int id { get; set; } //primary key
        public string gravitationalParameter { get; set; }

        public string mass { get; set; }

        public string volumeMeanRadius { get; set; }

        public string volume { get; set; }

        public string solarRadius { get; set; }
        public string radius { get; set; }

        public string angularDiameter { get; set; }

        public string photosphereTemperature { get; set; }

        public string photosphericDepth { get; set; }

        public string chromosphericDepth { get; set; }

        public string flatness { get; set; }

        public string surfaceGravity { get; set; }

        public string escapeSpeed { get; set; }

        public string rightAscension { get; set; }

        public string declination { get; set; }

        public string obliquityToEcliptic { get; set; }

        public string solarConstantOneAu { get; set; }

        public string luminosity { get; set; }

        public string massEnergyConversionRate { get; set; }

        public string effectiveTemperature { get; set; }

        public string sunspotCycle { get; set; }

        public string cycle24SunspotMinimum { get; set; }
        //foreign key
        public int barycenterId { get; set; }

        public Star(
            int id,
            string gravitationalParameter,
            string mass,
            string volumeMeanRadius,
            string volume,
            string solarRadius,
            string radius,
            string angularDiameter,
            string photosphereTemperature,
            string photosphericDepth,
            string chromosphericDepth,
            string flatness,
            string surfaceGravity,
            string escapeSpeed,
            string rightAscension,
            string declination,
            string obliquityToEcliptic,
            string solarConstantOneAu,
            string luminosity,
            string massEnergyConversionRate,
            string effectiveTemperature,
            string sunspotCycle,
            string cycle24SunspotMinimum,
            int barycenterId)
        {
            this.id = id;
            this.gravitationalParameter = gravitationalParameter;
            this.mass = mass;
            this.volumeMeanRadius = volumeMeanRadius;
            this.volume = volume;
            this.solarRadius = solarRadius;
            this.radius = radius;
            this.angularDiameter = angularDiameter;
            this.photosphereTemperature = photosphereTemperature;
            this.photosphericDepth = photosphericDepth;
            this.chromosphericDepth = chromosphericDepth;
            this.flatness = flatness;
            this.surfaceGravity = surfaceGravity;
            this.escapeSpeed = escapeSpeed;
            this.rightAscension = rightAscension;
            this.declination = declination;
            this.obliquityToEcliptic = obliquityToEcliptic;
            this.solarConstantOneAu = solarConstantOneAu;
            this.luminosity = luminosity;
            this.massEnergyConversionRate = massEnergyConversionRate;
            this.effectiveTemperature = effectiveTemperature;
            this.sunspotCycle = sunspotCycle;
            this.cycle24SunspotMinimum = cycle24SunspotMinimum;
            this.barycenterId = barycenterId;
        }

    }
}
