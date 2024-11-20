namespace OurSolarSystemAPI.Models
{
    public class Planet(
        int horizonId,
        int barycenterId,
        Barycenter barycenter,
        string name,
        string volumeMeanRadius,
        string density,
        string mass,
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
        string gravitationalParameter,
        ICollection<Moon> moons,
        ICollection<EphemerisPlanet> ephemeris,
        string solarConstantPerihelion,
        string solarConstantAphelion,
        string solarConstantMean,
        string maxPlanetaryIRPerihelion,
        string maxPlanetaryIRAphelion,
        string maxPlanetaryIRMean,
        string minPlanetaryIRPerihelion,
        string minPlanetaryIRAphelion,
        string minPlanetaryIRMean
        )
    {
        public int HorizonId = horizonId; // primary key 
        public int BarycenterId = barycenterId; // foreign key
        public Barycenter Barycenter = barycenter;
        public ICollection<Moon> Moons = moons;
        public ICollection<EphemerisPlanet> Ephemeris = ephemeris;
        public string Name = name;
        public string VolumeMeanRadius = volumeMeanRadius;
        public string Density = density;
        public string Mass = mass;
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
        public string GravitationalParameter = gravitationalParameter;
        string SolarConstantPerihelion = solarConstantPerihelion;
        string SolarConstantAphelion = solarConstantAphelion;
        string SolarConstantMean = solarConstantMean;
        string MaxPlanetaryIRPerihelion = maxPlanetaryIRPerihelion;
        string MaxPlanetaryIRAphelion = maxPlanetaryIRAphelion;
        string MaxPlanetaryIRMean = maxPlanetaryIRMean;
        string MinPlanetaryIRPerihelion = minPlanetaryIRPerihelion;
        string MinPlanetaryIRAphelion = minPlanetaryIRAphelion;
        string MinPlanetaryIRMean = minPlanetaryIRMean; 
    }
}
