using Neo4j.Driver;
using Neo4j.Driver.Mapping;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository.NEO4J 
{
    public class MoonRepositoryNEO4J 
    {
        private readonly IDriver _driver;

        public MoonRepositoryNEO4J(IDriver driver)
        {
            _driver = driver;
        }

        public Dictionary<string, object?> ConvertMoonAttributesToDict(Moon moon)
        {
            return new Dictionary<string, object?>
            {
                { "id", moon.Id },
                { "planetId", moon.PlanetId },
                { "horizonPlanetId", moon.HorizonPlanetId },
                { "planetName", moon.PlanetName },
                { "horizonId", moon.HorizonId },
                { "planet", moon.Planet },
                { "ephemeris", moon.Ephemeris },
                { "name", moon.Name },
                { "meanRadius", moon.MeanRadius },
                { "density", moon.Density },
                { "gm", moon.Gm },
                { "semiMajorAxis", moon.SemiMajorAxis },
                { "gravitationalParameter", moon.GravitationalParameter },
                { "geometricAlbedo", moon.GeometricAlbedo },
                { "orbitalPeriod", moon.OrbitalPeriod },
                { "eccentricity", moon.Eccentricity },
                { "rotationalPeriod", moon.RotationalPeriod },
                { "inclination", moon.Inclination }
            };
        }

        public Dictionary<string, object?> ConvertMoonOrbitalAttributesToDict(Moon moon)
        {
            return new Dictionary<string, object?>
            {
                { "semiMajorAxis", moon.SemiMajorAxis },
                { "gravitationalParameter", moon.GravitationalParameter },
                { "geometricAlbedo", moon.GeometricAlbedo },
                { "orbitalPeriod", moon.OrbitalPeriod },
                { "eccentricity", moon.Eccentricity },
                { "rotationalPeriod", moon.RotationalPeriod },
                { "inclination", moon.Inclination }
            };
        }

        public async Task<List<IRecord>> createMoonsNodesFromList(List<Dictionary<string, object>> moons, int planetHorizonId, string planetName) 
        {
            await using var session = _driver.AsyncSession();
            
            var parameters = new Dictionary<string, object> 
            {
                {"moons", moons},
                {"planetId", planetHorizonId},
                {"planetName", planetName}
            };

            var query = @"
                UNWIND $moons AS moon
                CREATE (m:moon)
                SET m = moon
                WITH m
                MATCH (b:Barycenter) WHERE b.Name = $planetName + ' Barycenter'
                CREATE (m)-[:ORBITS]->(b)
                MATCH (p:Planet) WHERE p.HorizonId = $planetId
                CREATE (m)-[:PART_OF_MOON_SYSTEM_OF]->(p)
                RETURN count(*) AS count";

                var result = await session.ExecuteWriteAsync(async tx =>
                {
                    var cursor = await tx.RunAsync(query, parameters);
                    return await cursor.ToListAsync();
                });
            return result;

        }

        public async Task<List<IRecord>> createMoonNodeFromMoonDict(Dictionary<string, object> moon, int planetHorizonId, string planetName) 
        {
            await using var session = _driver.AsyncSession();
            
            var parameters = new Dictionary<string, object> 
            {
                {"moon", moon},
                {"planetId", planetHorizonId},
                {"planetName", planetName}
            };

            var query = @"
                CREATE (m:Moon $moon)
                SET m = Moon
                WITH m
                MATCH (b:Barycenter) WHERE b.Name = $planetName + ' Barycenter'
                CREATE (m)-[:ORBITS]->(b)
                MATCH (p:Planet) WHERE p.HorizonId = $planetId
                CREATE (m)-[:PART_OF_MOON_SYSTEM_OF]->(p)
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