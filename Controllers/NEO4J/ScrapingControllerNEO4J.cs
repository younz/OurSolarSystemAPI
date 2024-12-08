using Microsoft.AspNetCore.Mvc;
using OurSolarSystemAPI.Service.NEO4J;

namespace OurSolarSystemAPI.Controllers.NEO4J; 

    [ApiController]
    [Route("scraping/neo4j")]
    public class ScrapingControllerNEO4J : ControllerBase
    {

        private readonly ScrapingServiceNEO4J _scrapingService;
        private readonly HttpClient _httpClient;

        public ScrapingControllerNEO4J(ScrapingServiceNEO4J scrapingService, HttpClient httpClient) 
        {
            _scrapingService = scrapingService;
            _httpClient = httpClient;

        }


        [HttpGet("scrape-barycenters")]
        public async Task<IActionResult> ScrapeBarycenters() 
        {
            await _scrapingService.ScrapeBarycenters(_httpClient);

            return Ok(new
            {
                statusCode = 200
            });
 
        }

        [HttpGet("scrape-planets")]
        public async Task<IActionResult> ScrapePlanets() 
        {
            await _scrapingService.ScrapePlanets(_httpClient);

            return Ok(new
            {
                statusCode = 200
            });
 
        }

        [HttpGet("scrape-moons")]
        public async Task<IActionResult> ScrapeMoons() 
        {
            await _scrapingService.ScrapeMoons(_httpClient);

            return Ok(new
            {
                statusCode = 200
            });
 
        }

        [HttpGet("scrape-satellites")]
        public async Task<IActionResult> ScrapeSatelittes() 
        {
            await _scrapingService.ScrapeArtificialSatellites(_httpClient);

            return Ok(new
            {
                statusCode = 200
            });
 
        }

}
    

