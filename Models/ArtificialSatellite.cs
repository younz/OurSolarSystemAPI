namespace OurSolarSystemAPI.Models
{
public class ArtificialSatellite(
    int planetId,
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
    string name)
    {
        private int PlanetID { get; set; } = planetId;
        private int LaunchDateDay { get; set; } = launchDateDay;
        private int LaunchDateMonth { get; set; } = launchDateMonth;
        private int LaunchDateYear { get; set; } = launchDateYear;
        private int LaunchSite { get; set; } = launchSite;
        private int Source { get; set; } = source;
        private int NoradId { get; set; } = noradId;
        private string NssdcId { get; set; } = nssdcId;
        private int Perigee { get; set; } = perigee;
        private int Apogee { get; set; } = apogee;
        private int Inclination { get; set; } = inclination;
        private int Period { get; set; } = period;
        private int SemiMajorAxis { get; set; } = semiMajorAxis;
        private int Rcs { get; set; } = rcs;
        private string Name { get; set; } = name;
    }
}
