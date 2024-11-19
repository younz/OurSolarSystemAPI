namespace OurSolarSystemAPI.Models
{
    public class Planet(
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
        int barycenterId)
    {
        public int ID = id; // primary key 
        public string Name = name;
        public string VolumeMeanRadius = volumeMeanRadius;
        public string Density = density;
        public string Mass = mass;
        public string Flattening = flattening;
        public string Volume = volume;
        public string EquatorialRadius = equatorialRadius;
        public string SiderealRotationPeriod = siderealRotationPeriod;
        public string SiderealRotationRate = siderealRotationRate;
        public string MeanSolarDay = meanSolarDay;
        public string PolarGravity = polarGravity;
        public string EquatorialGravity = equatorialGravity;
        public string GeometricAlbedo = geometricAlbedo;
        public string MassRatioToSun = massRatioToSun;
        public string MeanTemperature = meanTemperature;
        public string AtmosphericPressure = atmosphericPressure;
        public string ObliquityToOrbit = obliquityToOrbit;
        public string MaxAngularDiameter = maxAngularDiameter;
        public string MeanSideRealOrbitalPeriod = meanSideRealOrbitalPeriod;
        public string OrbitalSpeed = orbitalSpeed;
        public string HillsSphereRadius = hillsSphereRadius;
        public string EscapeSpeed = escapeSpeed;
        public string SolarConstant = solarConstant;
        public string MaximumPlanetaryIr = maximumPlanetaryIr;
        public string MinimumPlanetaryIr = minimumPlanetaryIr;
        public string GravitationalParameter = gravitationalParameter;
        public List<Moon> Moons = moons;
        public int BarycenterId = barycenterId; // foreign key
    }
}
