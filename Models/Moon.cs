using System.Collections.Generic;

namespace OurSolarSystemAPI.Models
{
    public class Moon(
        int id,
        int planetId,
        Planet planet,
        string name,
        string meanRadius,
        string density,
        string gravitationalParameter,
        string geometricAlbedo,
        ICollection<EphemerisMoon> ephemeris)
    {
    public int Id = id;
    public int PlanetId = planetId; // foreign key
    public Planet Planet = planet;
    public string Name = name;
    public string MeanRadius = meanRadius;
    public string Density = density;
    public string GravitationalParameter = gravitationalParameter;
    public string GeometricAlbedo = geometricAlbedo;
    public ICollection<EphemerisMoon> Ephemeris = ephemeris;
    }

}
