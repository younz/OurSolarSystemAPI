using OurSolarSystemAPI.Models;
using SGPdotNET.CoordinateSystem;
using SGPdotNET.Util;
using SGPdotNET.TLE;
using SGPdotNET.Propagation;

namespace OurSolarSystemAPI.Utility 
{
    public class CelesTrakScraper
    {
        public List<ArtificialSatellite> ScrapeAndConvertTle(string urlCelesTrak) 
        {
            var satellites = new List<ArtificialSatellite>();
            var url = new Uri(urlCelesTrak);
            DateTime scrapedAt = DateTime.Now;
            var provider = new RemoteTleProvider(true, url);
            var tles = provider.GetTles();

            foreach (KeyValuePair<int, Tle> entry in tles) {
                Tle tle = entry.Value; 
                var sgp4 = new Sgp4(tle);
                EciCoordinate eciCoords = sgp4.FindPosition(DateTime.Now);

                var ephemeris = new EphemerisArtificialSatellite()
                {
                    PositionX = eciCoords.Position.X,
                    PositionY = eciCoords.Position.Y,
                    PositionZ = eciCoords.Position.Z,
                    VelocityX = eciCoords.Velocity.X,
                    VelocityY = eciCoords.Velocity.Y,
                    VelocityZ = eciCoords.Velocity.Z,
                    Epoch = tle.Epoch.ToString(),
                    DateTime = scrapedAt
                };

                var tleArtificialSatellite = new TleArtificialSatellite() 
                {
                    Tle = tle.ToString(),
                    ScrapedAt = scrapedAt
                };

                satellites.Add(new ArtificialSatellite() 
                {
                    Name = tle.Name,
                    NoradId = (int) tle.NoradNumber,
                    BStarDragTerm = tle.BStarDragTerm.ToString(),
                    Tle = [tleArtificialSatellite],
                    Inclination = tle.Inclination.ToString(),
                    Apogee = tle.ArgumentPerigee.ToString(),
                    NssdcId = tle.IntDesignator,
                    Eccentricity = tle.Eccentricity.ToString(),
                    MeanAnomaly = tle.MeanAnomaly.ToString(),
                    OrbitNumber = tle.OrbitNumber.ToString()
                }

                    );
            }

            return satellites;
        }

        

    }

}