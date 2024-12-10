using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository.MySQL;

namespace OurSolarSystemAPI.Service.MySQL 
{
    public class ScrapingServiceMySQL 
    {
        private readonly ArtificialSatelliteRepositoryMySQL _artificialSatelliteRepo;
        private readonly BarycenterRepositoryMySQL _barycenterRepo;
        private readonly PlanetRepositoryMySQL _planetRepo;
        private readonly MoonRepositoryMySQL _moonRepo;
        private readonly ScrapingService _scrapingService;

        public ScrapingServiceMySQL(
            ArtificialSatelliteRepositoryMySQL artificialSatelliteRepo,
            BarycenterRepositoryMySQL barycenterRepo,
            PlanetRepositoryMySQL planetRepo,
            MoonRepositoryMySQL moonRepo,
            ScrapingService scrapingService) 
        {
             _artificialSatelliteRepo = artificialSatelliteRepo;
             _barycenterRepo = barycenterRepo;
             _planetRepo = planetRepo;
             _moonRepo = moonRepo;
             _scrapingService = scrapingService;
        }

        public async Task ScrapeBarycenters(HttpClient httpClient) 
        {
            List<Barycenter> barycenters = await _scrapingService.ScrapeBarycenters(httpClient);

            foreach (Barycenter barycenter in barycenters) 
            {
                _barycenterRepo.CreateBarycenter(barycenter);
            }
        }

        public async Task ScrapePlanets(HttpClient httpClient) 
        {
            List<Planet> planets = await _scrapingService.ScrapePlanets(httpClient);

            foreach (Planet planet in planets) 
            {
                _planetRepo.CreatePlanet(planet);
            }
        }

        public async Task ScrapeMoons(HttpClient httpClient) 
        {
            List<List<Moon>> moonlists = await _scrapingService.ScrapeMoons(httpClient);

            foreach (List<Moon> moonList in moonlists) 
            {
                _planetRepo.AddMoonsToExistingPlanet(moonList, moonList[0].HorizonPlanetId);
            }
        }

        public async Task ScrapeArtificialSatellites(HttpClient httpClient) 
        {
            List<ArtificialSatellite> satellites = await _scrapingService.ScrapeArtificialSatellites(httpClient);

            foreach (ArtificialSatellite satellite in satellites) 
            {
                _artificialSatelliteRepo.AddSatellite(satellite);
            }
        }

    
    }

}