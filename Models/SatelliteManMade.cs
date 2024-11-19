namespace OurSolarSystemAPI.Models
{
public class SatelliteManMade
{
    private int planetId { get; set; } // foreign key
    private int launchDateDay { get; set; }
    private int launchDateMonth { get; set; }
    private int launchDateYear { get; set; }
    private int launchSite { get; set; }
    private int source { get; set; }
    private int noradId { get; set; }
    private string nssdcId { get; set; }
    private int perigee { get; set; }
    private int apogee { get; set; }
    private int inclination { get; set; }
    private int period { get; set; }
    private int semiMajorAxis { get; set; }
    private int rcs { get; set; }
    private string name { get; set; }

    public SatelliteManMade(
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
        this.planetId = planetId;
        this.launchDateDay = launchDateDay;
        this.launchDateMonth = launchDateMonth;
        this.launchDateYear = launchDateYear;
        this.launchSite = launchSite;
        this.source = source;
        this.noradId = noradId;
        this.nssdcId = nssdcId;
        this.perigee = perigee;
        this.apogee = apogee;
        this.inclination = inclination;
        this.period = period;
        this.semiMajorAxis = semiMajorAxis;
        this.rcs = rcs;
        this.name = name;
    }
}

}
