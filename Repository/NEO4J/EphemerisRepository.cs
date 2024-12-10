using Neo4j.Driver;
using Neo4j.Driver.Mapping;

namespace OurSolarSystemAPI.Repository.NEO4J 
{
    public class EphemerisRepositoryNEO4J 
    {
        private readonly IDriver _driver;

        public EphemerisRepositoryNEO4J(IDriver driver)
        {
            _driver = driver;
        }

        public async Task<List<IRecord>> createEphimerisNodesFromList(List<Dictionary<string, object>> ephemeris, int horizonId, string relatedNode) 
        {
            await using var session = _driver.AsyncSession();
            
            var parameters = new Dictionary<string, object> 
            {
                {"ephemerisData", ephemeris},
                {"horizonId", horizonId}
            };

            var query = @$"
                UNWIND $ephemerisData AS ephemeris
                CREATE (e:ephemeris)
                SET e = ephemeris
                WITH e
                MATCH (x:{relatedNode}) WHERE x.HorizonId = $horizonId
                CREATE (x)-[:HAS_LOCATION]->(e)
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