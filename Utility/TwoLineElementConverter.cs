using System.Collections.Generic;
using SGPdotNET.CoordinateSystem;
using SGPdotNET.Util;
using SGPdotNET.TLE;
using SGPdotNET.Propagation;
using OurSolarSystemAPI.Models;


namespace OurSolarSystemAPI.Utility {

    public struct SatelliteDataCelesTrak(string name, string noradNumber, string bStarDragTerm, Vector3 position, Vector3 velocity)
    {
        public string name = name;
        public string noradNumber = noradNumber;
        public string bStarDragTerm = bStarDragTerm;
        public Vector3 position = position;
        public Vector3 velocity = velocity;
    }

    public class TwoLineElementConverter() 
    {
        public List<ArtificialSatellite> Convert(string urlCelesTrak) 
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

                satellites.Add(new ArtificialSatellite() 
                {
                    Name = tle.Name,
                    NoradId = tle.NoradNumber.ToString(),
                    BStarDragTerm = tle.BStarDragTerm.ToString(),
                    Ephemeris = ephemeris,
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

                        // new Dictionary<string, object>
                    // {
                    //     { "Name", tle.Name },
                    //     { "NoradNumber", tle.NoradNumber.ToString() },
                    //     { "BStarDragTerm", tle.BStarDragTerm.ToString() },
                    //     { "PositionX", eciCoords.Position.X },
                    //     { "PositionY", eciCoords.Position.Y },
                    //     { "PositionZ", eciCoords.Position.Z },
                    //     { "VelocityX", eciCoords.Velocity.X },
                    //     { "VelocityY", eciCoords.Velocity.Y },
                    //     { "VelocityZ", eciCoords.Velocity.Z },
                    //     { "dateTime", DateTime.Now}
                    // }


}