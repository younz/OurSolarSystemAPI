namespace OurSolarSystemAPI.Models
{
    public class Moon(
        int id,
        string name,
        string meanRadius,
        string density,
        string gravitationalParameter,
        string geometricAlbedo,
        int planetId)
    {
    public int ID = id;
    public string Name = name;
    public string MeanRadius = meanRadius;
    public string Density = density;
    public string GravitationalParameter = gravitationalParameter;
    public string GeometricAlbedo = geometricAlbedo;
    public int PlanetId = planetId; // foreign key
    }

}
