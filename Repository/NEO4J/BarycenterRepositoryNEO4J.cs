using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Utility;
using Neo4j.Driver;
using Neo4j.Driver.Mapping;


namespace OurSolarSystemAPI.Repository.NEO4J 
{

    public class BarycenterRepositoryNEO4J 
    {
        private readonly IDriver _driver;

        public BarycenterRepositoryNEO4J(IDriver driver)
        {
            _driver = driver;
        }

        public async Task<string?> CreateNodeSolarSystemBarycenter(Barycenter solarSystemBarycenter) 
        {
            await using var session = _driver.AsyncSession();
            var parameters = new Dictionary<string, object>
            {
                { "props", ObjectToDictConverter.ConvertToDictionary(solarSystemBarycenter) }
            };

            var query = "CREATE (b:Barycenter $props) RETURN b";
            var result = await session.ExecuteWriteAsync(async tx =>
                {
                    var cursor = await tx.RunAsync(query, parameters);
                    return await cursor.SingleAsync();
                });



            var node = result["b"].As<INode>();
            var name = node.Properties["Name"].As<string>();

            return node.Properties["Name"].As<string>();
        }



        public async Task<List<IRecord>> CreateNodesPlanetMoonSystemBarycenters(List<Dictionary<string, object>> barycenters) 
        {
            await using var session = _driver.AsyncSession();
            
            var parameters = new Dictionary<string, object> 
            {
                {"barycenters", barycenters},
                {"SolarSystemBarycenterName", "Solar System Barycenter"}
            };

            var query = @"
                UNWIND $barycenters AS barycenter
                CREATE (b:Barycenter)
                SET b = barycenter
                WITH b
                MATCH (ssb:Barycenter) WHERE ssb.Name = $SolarSystemBarycenterName
                CREATE (b)-[:BELONGS_TO]->(ssb)
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