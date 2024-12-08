using OurSolarSystemAPI.Models;
using Neo4j.Driver;
using Neo4j.Driver.Mapping;

namespace OurSolarSystemAPI.Repository.NEO4J 
{
    public class ArtificialSatelliteRepositoryNEO4J 
    {
        private readonly IDriver _driver;

        public ArtificialSatelliteRepositoryNEO4J(IDriver driver)
        {
            _driver = driver;
        }

        public Dictionary<string, object?> ConvertSatelliteAttributesToDict(ArtificialSatellite satellite)
        {
            var satelliteDict = new Dictionary<string, object?>();

            satelliteDict["tle"] = satellite.Tle;  
            satelliteDict["launchDate"] = satellite.LaunchDate;
            satelliteDict["launchSite"] = satellite.LaunchSite;
            satelliteDict["bStarDragTerm"] = satellite.BStarDragTerm;
            satelliteDict["eccentricity"] = satellite.Eccentricity;
            satelliteDict["meanAnomaly"] = satellite.MeanAnomaly;
            satelliteDict["orbitNumber"] = satellite.OrbitNumber;
            satelliteDict["source"] = satellite.Source;
            satelliteDict["noradId"] = satellite.NoradId;
            satelliteDict["nssdcId"] = satellite.NssdcId;
            satelliteDict["perigee"] = satellite.Perigee;
            satelliteDict["apogee"] = satellite.Apogee;
            satelliteDict["inclination"] = satellite.Inclination;
            satelliteDict["period"] = satellite.Period;
            satelliteDict["semiMajorAxis"] = satellite.SemiMajorAxis;
            satelliteDict["rcs"] = satellite.Rcs;
            satelliteDict["name"] = satellite.Name;

            return satelliteDict;
        }

        public Dictionary<string, object?> ConvertSatelliteOrbitalAttributesToDict(ArtificialSatellite satellite)
        {
            var satelliteDict = new Dictionary<string, object?>();

            satelliteDict["bStarDragTerm"] = satellite.BStarDragTerm;
            satelliteDict["eccentricity"] = satellite.Eccentricity;
            satelliteDict["meanAnomaly"] = satellite.MeanAnomaly;
            satelliteDict["orbitNumber"] = satellite.OrbitNumber;
            satelliteDict["perigee"] = satellite.Perigee;
            satelliteDict["apogee"] = satellite.Apogee;
            satelliteDict["inclination"] = satellite.Inclination;
            satelliteDict["period"] = satellite.Period;
            satelliteDict["semiMajorAxis"] = satellite.SemiMajorAxis;

            return satelliteDict;
        }

        public async Task<List<IRecord>> createSatelliteNodesFromList(List<Dictionary<string, object>> satellites, int celestialBodyHorizonId) 
        {
            await using var session = _driver.AsyncSession();
            
            var parameters = new Dictionary<string, object> 
            {
                {"satelittes", satellites},
                {"celestialBodyId", celestialBodyHorizonId}
            };

            var query = @"
                UNWIND $satellites AS satellite
                CREATE (s:satellite)
                SET s = satellite
                WITH s
                MATCH (p:Planet) WHERE p.HorizonId = $celestialBodyId
                CREATE (s)-[:ORBITS]->(p)
                RETURN count(*) AS count";

                var result = await session.ExecuteWriteAsync(async tx =>
                {
                    var cursor = await tx.RunAsync(query, parameters);
                    return await cursor.ToListAsync();
                });
            return result;

        }

        public async Task<List<IRecord>> createSatelliteNodeFromObject(List<Dictionary<string, object>> satellites, int celestialBodyHorizonId) 
        {
            await using var session = _driver.AsyncSession();
            
            var parameters = new Dictionary<string, object> 
            {
                {"satelittes", satellites},
                {"celestialBodyId", celestialBodyHorizonId}
            };

            var query = @"
                UNWIND $satellites AS satellite
                CREATE (s:satellite)
                SET s = satellite
                WITH s
                MATCH (p:Planet) WHERE p.HorizonId = $celestialBodyId
                CREATE (s)-[:ORBITS]->(p)
                RETURN count(*) AS count";

                var result = await session.ExecuteWriteAsync(async tx =>
                {
                    var cursor = await tx.RunAsync(query, parameters);
                    return await cursor.ToListAsync();
                });
            return result;

        }
    }
    
}