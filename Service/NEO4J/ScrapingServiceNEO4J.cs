using Microsoft.VisualBasic;
using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository.NEO4J;
using OurSolarSystemAPI.Utility;
using SGPdotNET.Observation;

namespace OurSolarSystemAPI.Service.NEO4J 
{
    public class ScrapingServiceNEO4J 
    {
        private readonly ArtificialSatelliteRepositoryNEO4J _artificialSatelliteRepo;
        private readonly BarycenterRepositoryNEO4J _barycenterRepo;
        private readonly PlanetRepositoryNEO4J _planetRepo;
        private readonly MoonRepositoryNEO4J _moonRepo;
        private readonly EphemerisRepositoryNEO4J _ephemerisRepo;
        private readonly ScrapingService _scrapingService;

        public ScrapingServiceNEO4J(
            ArtificialSatelliteRepositoryNEO4J artificialSatelliteRepo,
            BarycenterRepositoryNEO4J barycenterRepo,
            PlanetRepositoryNEO4J planetRepo,
            MoonRepositoryNEO4J moonRepo,
            EphemerisRepositoryNEO4J ephemerisRepo,
            ScrapingService scrapingService) 
        {
             _artificialSatelliteRepo = artificialSatelliteRepo;
             _barycenterRepo = barycenterRepo;
             _planetRepo = planetRepo;
             _moonRepo = moonRepo;
             _ephemerisRepo = ephemerisRepo;
             _scrapingService = scrapingService;
        }

        public async Task ScrapeBarycenters(HttpClient httpClient) 
        {
            List<Barycenter> barycenters = await _scrapingService.ScrapeBarycenters(httpClient);
            var barycenterDicts = new List<Dictionary<string, object>>();

            await _barycenterRepo.CreateNodeSolarSystemBarycenter(barycenters[0]);
            barycenters.RemoveAt(0);

            foreach (var barycenter in barycenters) 
            {
                barycenterDicts.Add(ObjectToDictConverter.ConvertToDictionary(barycenter));
            }

            await _barycenterRepo.CreateNodesPlanetMoonSystemBarycenters(barycenterDicts);
        }

        public async Task ScrapePlanets(HttpClient httpClient) 
        {
            List<Planet> planets = await _scrapingService.ScrapePlanets(httpClient);
            var planetDicts = new List<Dictionary<string, object>>();

            foreach (Planet planet in planets) 
            {
                planetDicts.Add(ObjectToDictConverter.ConvertToDictionary(planet));
            }

            await _planetRepo.createPlanetNodesFromList(planetDicts);

        }

        public async Task ScrapeMoons(HttpClient httpClient) 
        {
            List<List<Moon>> moonlists = await _scrapingService.ScrapeMoons(httpClient);

            foreach (List<Moon> moonlist in moonlists) 
            {
                foreach (Moon moon in moonlist) 
                {
                    Dictionary<string, object> moonDict = ObjectToDictConverter.ConvertToDictionary(moon);
                    var ephemerisDicts = new List<Dictionary<string, object>>();
                    await _moonRepo.createMoonNodeFromMoonDict(moonDict, moon.HorizonPlanetId, moon.PlanetName);


                    _ = moon.Ephemeris ?? throw new InvalidOperationException("moon.Ephemeris is null.");
                    foreach (EphemerisMoon ephemeris in moon.Ephemeris) 
                    {
                        ephemerisDicts.Add(ObjectToDictConverter.ConvertToDictionary(ephemeris));
                    }
                    await _ephemerisRepo.createEphimerisNodesFromList(ephemerisDicts, moon.HorizonId, "Moon");
                }

            }
        }

        public async Task ScrapeArtificialSatellites(HttpClient httpClient) 
        {
            List<ArtificialSatellite> satellites = await _scrapingService.ScrapeArtificialSatellites(httpClient);
            var satelliteDicts = new List<Dictionary<string, object>>();

            foreach (ArtificialSatellite satellite in satellites) 
            {
                satelliteDicts.Add(ObjectToDictConverter.ConvertToDictionary(satellite));
            }

            await _artificialSatelliteRepo.createSatelliteNodesFromList(satelliteDicts, 399);

        }

    
    }

}