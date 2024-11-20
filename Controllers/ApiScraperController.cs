using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using OurSolarSystemAPI.Utility;
using OurSolarSystemAPI.Service;
using OurSolarSystemAPI.Repository;
using OurSolarSystemAPI.Models;
namespace OurSolarSystemAPI.Controllers;

[ApiController]
[Route("")]
public class ApiScraperController : ControllerBase
{
    private readonly OurSolarSystemContext _context;
    private readonly HorizonService _horizonService;
    private readonly HttpClient _httpClient;

    public ApiScraperController(HorizonService horizonService, OurSolarSystemContext context, HttpClient httpClient) 
    {
        _horizonService = horizonService;
        _context = context;
        _httpClient = httpClient;
    }

    [HttpGet("horizon-scrape-moon-data/{horizonId}")]
    public async Task<IActionResult> ScrapeHorizonMoonData(int horizonId)
    {

        return Ok(new
            {
                StatusCode = 200
            });

    }


    [HttpGet("horizon-create-barycenters-db")]
    public async Task<IActionResult> CreateBarycenterDataDB()
    {
        _horizonService.ScrapeAndAddBarycentersToDB(_httpClient);

        return Ok(new
            {
                statusCode = 200
            });
    }

    [HttpGet("horizon-create-planets")]
    public IActionResult CreatePlanetDataDB()
    {
        _horizonService.AddHardcodedPlanetsToDB();

        return Ok(new
            {
                statusCode = 200
            });
    }




    [HttpGet("celestrak-scrape-satellite")]
    public IActionResult GetHorizonPlanetData()
    {
        string url = $"https://celestrak.org/NORAD/elements/supplemental/sup-gp.php?INTDES=2023-099&FORMAT=tle";
        var twoLineElementConverter =  new TwoLineElementConverter();
        List<Dictionary<string, Object>> satelliteInfo = twoLineElementConverter.Convert(url);
        
        return Ok(new
            {
                satelliteInfo = satelliteInfo,
            });
    }

    [HttpGet("n2yo-scrape-satellite/{noradNumber}")]
    public async Task<IActionResult> GetN2yoSatelliteData(int noradNumber)
    {
        string url = $"https://www.n2yo.com/satellite/?s={noradNumber}";
        var httpClient = new HttpClient();
        var n2yoScraper = new N2yoScraper();
        string htmlContent = await UtilityGetRequest.PerformRequest(url, httpClient);
        httpClient.Dispose();

        Dictionary<string, string> satelliteInfo = n2yoScraper.ExtractSatelliteInfoFromHtml(htmlContent);
        return Ok(new
            {
                satelliteInfo = satelliteInfo,
            });

    }

}    
