using System.Collections.Generic;
using SGPdotNET.CoordinateSystem;
using SGPdotNET.Util;
using SGPdotNET.TLE;
using SGPdotNET.Propagation;


namespace OurSolarSystemAPI.Utility {

    public struct SatelliteDataCelesTrak {
        public string name;
        public string noradNumber;
        public string bStarDragTerm;
        public Vector3 position;
        public Vector3 velocity;

        public SatelliteDataCelesTrak(string name, string noradNumber, string bStarDragTerm, Vector3 position, Vector3 velocity) {
            this.name = name;
            this.noradNumber = noradNumber;
            this.bStarDragTerm = bStarDragTerm;
            this.position = position;
            this.velocity = velocity;
        }
    }

    public class TwoLineElementConverter() 
    {
        public List<Dictionary<string, string>> Convert(string urlCelesTrak) 
        {
            var satellites = new List<Dictionary<string, string>>();
            var url = new Uri(urlCelesTrak);
            var provider = new RemoteTleProvider(true, url);
            var tles = provider.GetTles();

            foreach (KeyValuePair<int, Tle> entry in tles) {
                Tle tle = entry.Value; 
                var sgp4 = new Sgp4(tle);
                EciCoordinate eciCoords = sgp4.FindPosition(DateTime.Now);
                satellites.Add(
                    new Dictionary<string, string>
                    {
                        { "Name", tle.Name },
                        { "NoradNumber", tle.NoradNumber.ToString() },
                        { "BStarDragTerm", tle.BStarDragTerm.ToString() },
                        { "Position", eciCoords.Position.ToString() },
                        { "Velocity", eciCoords.Velocity.ToString() }
                    }
                    );
            }

            return satellites;
        }

    }


}