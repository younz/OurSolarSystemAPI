using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using OurSolarSystemAPI.Utility;

namespace OurSolarSystemAPI.Controllers;

[ApiController]
[Route("")]
public class ApiScraperController : ControllerBase
{


    [HttpGet("horizon-scraper-moon/{horizonId}")]
    public async Task<IActionResult> GetHorizonMoonData(int horizonId)
    {
        var httpClient = new HttpClient();
        var horizonScraper = new HorizonScraper();
        string url = $"?format=text&COMMAND='{horizonId}'&center='@0'&ephem_type='Vectors'&vec_table=2&step_size=1d&start_time=2024-01-01&stop_time=2024-01-02";

        string apiResponse = await UtilityGetRequest.performRequest(url, httpClient);
        httpClient.Dispose();

        List<Dictionary<string, string>> ephemeris = horizonScraper.extractEphemeris(apiResponse);
        Dictionary<string, string> moonData = horizonScraper.extractMoonData(apiResponse);

        return Ok(new
            {
                moonData = moonData,
                ephemeris = ephemeris
            });

    }


    [HttpGet("celestrak-scraper-satellite")]
    public IActionResult GetHorizonPlanetData()
    {
        string url = $"https://celestrak.org/NORAD/elements/supplemental/sup-gp.php?INTDES=2023-099&FORMAT=tle";
        var twoLineElementConverter =  new TwoLineElementConverter();
        List<Dictionary<string, string>> satelliteInfo = twoLineElementConverter.convert(url);
        
        return Ok(new
            {
                satelliteInfo = satelliteInfo,
            });
    }

    [HttpGet("n2yo-scraper-satellite/{noradNumber}")]
    public async Task<IActionResult> GetN2yoSatelliteData(int noradNumber)
    {
        string url = $"https://www.n2yo.com/satellite/?s={noradNumber}";
        var httpClient = new HttpClient();
        var n2yoScraper = new N2yoScraper();
        string htmlContent = await UtilityGetRequest.performRequest(url, httpClient);
        httpClient.Dispose();

        Dictionary<string, string> satelliteInfo = n2yoScraper.extractSatelliteInfoFromHtml(htmlContent);
        return Ok(new
            {
                satelliteInfo = satelliteInfo,
            });

    }

}    
