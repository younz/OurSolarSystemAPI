using System.Collections.Generic;
using SGPdotNET.CoordinateSystem;
using SGPdotNET.Util;
using SGPdotNET.TLE;
using SGPdotNET.Propagation;


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
        public List<Dictionary<string, object>> Convert(string urlCelesTrak) 
        {
            var satellites = new List<Dictionary<string, object>>();
            var url = new Uri(urlCelesTrak);
            var provider = new RemoteTleProvider(true, url);
            var tles = provider.GetTles();

            foreach (KeyValuePair<int, Tle> entry in tles) {
                Tle tle = entry.Value; 
                var sgp4 = new Sgp4(tle);
                EciCoordinate eciCoords = sgp4.FindPosition(DateTime.Now);
                satellites.Add(
                    new Dictionary<string, object>
                    {
                        { "Name", tle.Name },
                        { "NoradNumber", tle.NoradNumber.ToString() },
                        { "BStarDragTerm", tle.BStarDragTerm.ToString() },
                        { "PositionX", eciCoords.Position.X },
                        { "PositionY", eciCoords.Position.Y },
                        { "PositionZ", eciCoords.Position.Z },
                        { "VelocityX", eciCoords.Velocity.X },
                        { "VelocityY", eciCoords.Velocity.Y },
                        { "VelocityZ", eciCoords.Velocity.Z }
                    }
                    );
            }

            return satellites;
        }

    }


}