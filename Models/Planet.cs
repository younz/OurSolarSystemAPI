namespace OurSolarSystemAPI.Models
{
    public class Planet
    {
        private int id { get; set; } // primary key 
        private string name { get; set; }
        private string volumeMeanRadius { get; set; }
        private string density { get; set; }
        private string mass { get; set; }
        private string flattening { get; set; }
        private string volume { get; set; }
        private string equatorialRadius { get; set; }
        private string siderealRotationPeriod { get; set; }
        private string siderealRotationRate { get; set; }
        private string meanSolarDay { get; set; }
        private string polarGravity { get; set; }
        private string equatorialGravity { get; set; }
        private string geometricAlbedo { get; set; }
        private string massRatioToSun { get; set; }
        private string meanTemperature { get; set; }
        private string atmosphericPressure { get; set; }
        private string obliquityToOrbit { get; set; }
        private string maxAngularDiameter { get; set; }
        private string meanSideRealOrbitalPeriod { get; set; }
        private string orbitalSpeed { get; set; }
        private string hillsSphereRadius { get; set; }
        private string escapeSpeed { get; set; }
        private string solarConstant { get; set; }
        private string maximumPlanetaryIr { get; set; }
        private string minimumPlanetaryIr { get; set; }
        private string gravitationalParameter { get; set; }
        private List<Moon> moons { get; set; } = new List<Moon>();
        private int barycenterId { get; set; } // foreign key

        public Planet(
            int id,
            string name,
            string volumeMeanRadius,
            string density,
            string mass,
            string flattening,
            string volume,
            string equatorialRadius,
            string siderealRotationPeriod,
            string siderealRotationRate,
            string meanSolarDay,
            string polarGravity,
            string equatorialGravity,
            string geometricAlbedo,
            string massRatioToSun,
            string meanTemperature,
            string atmosphericPressure,
            string obliquityToOrbit,
            string maxAngularDiameter,
            string meanSideRealOrbitalPeriod,
            string orbitalSpeed,
            string hillsSphereRadius,
            string escapeSpeed,
            string solarConstant,
            string maximumPlanetaryIr,
            string minimumPlanetaryIr,
            string gravitationalParameter,
            List<Moon> moons,
            int barrycenterId)
            {
                this.id = id;
                this.name = name;
                this.volumeMeanRadius = volumeMeanRadius;
                this.density = density;
                this.mass = mass;
                this.flattening = flattening;
                this.volume = volume;
                this.equatorialRadius = equatorialRadius;
                this.siderealRotationPeriod = siderealRotationPeriod;
                this.siderealRotationRate = siderealRotationRate;
                this.meanSolarDay = meanSolarDay;
                this.polarGravity = polarGravity;
                this.equatorialGravity = equatorialGravity;
                this.geometricAlbedo = geometricAlbedo;
                this.massRatioToSun = massRatioToSun;
                this.meanTemperature = meanTemperature;
                this.atmosphericPressure = atmosphericPressure;
                this.obliquityToOrbit = obliquityToOrbit;
                this.maxAngularDiameter = maxAngularDiameter;
                this.meanSideRealOrbitalPeriod = meanSideRealOrbitalPeriod;
                this.orbitalSpeed = orbitalSpeed;
                this.hillsSphereRadius = hillsSphereRadius;
                this.escapeSpeed = escapeSpeed;
                this.solarConstant = solarConstant;
                this.maximumPlanetaryIr = maximumPlanetaryIr;
                this.minimumPlanetaryIr = minimumPlanetaryIr;
                this.gravitationalParameter = gravitationalParameter;
                this.moons = moons;
                this.barycenterId = barycenterId;
            }
            }
}
