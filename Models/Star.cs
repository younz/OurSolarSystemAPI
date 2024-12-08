using System.Text.Json.Serialization;

namespace OurSolarSystemAPI.Models
{
    public class Star(
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
        [JsonIgnore]
        public int id { get; set; } = id;
        public string gravitationalParameter { get; set; } = gravitationalParameter;

        public string mass { get; set; } = mass;

        public string volumeMeanRadius { get; set; } = volumeMeanRadius;

        public string volume { get; set; } = volume;

        public string solarRadius { get; set; } = solarRadius;
        public string radius { get; set; } = radius;

        public string angularDiameter { get; set; } = angularDiameter;

        public string photosphereTemperature { get; set; } = photosphereTemperature;

        public string photosphericDepth { get; set; } = photosphericDepth;

        public string chromosphericDepth { get; set; } = chromosphericDepth;

        public string flatness { get; set; } = flatness;

        public string surfaceGravity { get; set; } = surfaceGravity;

        public string escapeSpeed { get; set; } = escapeSpeed;

        public string rightAscension { get; set; } = rightAscension;

        public string declination { get; set; } = declination;

        public string obliquityToEcliptic { get; set; } = obliquityToEcliptic;

        public string solarConstantOneAu { get; set; } = solarConstantOneAu;

        public string luminosity { get; set; } = luminosity;

        public string massEnergyConversionRate { get; set; } = massEnergyConversionRate;

        public string effectiveTemperature { get; set; } = effectiveTemperature;

        public string sunspotCycle { get; set; } = sunspotCycle;

        public string cycle24SunspotMinimum { get; set; } = cycle24SunspotMinimum;
        //foreign key
        public int barycenterId { get; set; } = barycenterId;
    }
}
