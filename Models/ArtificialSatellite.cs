using System.Numerics;

namespace OurSolarSystemAPI.Models
{
public class ArtificialSatellite(
    int id,
    int planetId,
    Planet planet,
    int launchDateDay,
    int launchDateMonth,
    int launchDateYear,
    int launchSite,
    int source,
    int noradId,
    string nssdcId,
    int perigee,
    int apogee,
    int inclination,
    int period,
    int semiMajorAxis,
    int rcs,
    string name,
    ICollection<EphemerisArtificialSatellite> ephemeris)
    {
        public int Id = id;
        public int PlanetId = planetId;
        public Planet Planet = planet;
        public int LaunchDateDay = launchDateDay;
        public int LaunchDateMonth = launchDateMonth;
        public int LaunchDateYear = launchDateYear;
        public int LaunchSite = launchSite;
        public int Source = source;
        public int NoradId = noradId;
        public string NssdcId = nssdcId;
        public int Perigee = perigee;
        public int Apogee = apogee;
        public int Inclination = inclination;
        public int Period = period;
        public int SemiMajorAxis = semiMajorAxis;
        public int Rcs = rcs;
        public string Name = name;
        public ICollection<EphemerisArtificialSatellite> Ephemeris = ephemeris;
    }
}
