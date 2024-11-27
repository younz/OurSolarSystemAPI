using Microsoft.AspNetCore.Mvc;
using OurSolarSystemAPI.Service;
using OurSolarSystemAPI.Repository;
namespace OurSolarSystemAPI.Controllers;

[ApiController]
[Route("")]
public class ScrapingController : ControllerBase
{
    private readonly OurSolarSystemContext _context;
    private readonly ScrapingService _scrapingService;
    private readonly HttpClient _httpClient;

    public ScrapingController(ScrapingService scrapingService, OurSolarSystemContext context, HttpClient httpClient) 
    {
        _scrapingService = scrapingService;
        _context = context;
        _httpClient = httpClient;
    }

    [HttpGet("scrape-barycenters")]
    public async Task<IActionResult> ScrapeAndAddBarycentersToDB()
    {
        await _scrapingService.ScrapeAndAddBarycentersToDB(_httpClient);

        return Ok(new
            {
                statusCode = 200
            });
    }


    [HttpGet("scrape-planets")]
    public async Task<IActionResult> AddPlanetsToDataDB()
    {
        await _scrapingService.AddHardcodedPlanetsToDB(_httpClient);

        return Ok(new
            {
                statusCode = 200
            });
    }

    [HttpGet("scrape-moons")]
    public async Task<IActionResult> CreateBarycenterDataDB()
    {
        await _scrapingService.ScrapeAndAddMoonsToDB(_httpClient);

        return Ok(new
            {
                statusCode = 200
            });
    }

    [HttpGet("scrape-satellites")]
    public async Task<IActionResult> GetHorizonPlanetData()
    {
       await _scrapingService.ScrapeAndAddArtificialSatellitesToDB(_httpClient);
        
        return Ok(new
            {
                StatusCode = 200
            });
    }
}    
