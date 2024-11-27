using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OurSolarSystemAPI.Service;

namespace OurSolarSystemAPI.Controllers.MySQL 
{
    [ApiController]
    [Route("api/mysql")]
    public class PlanetController : ControllerBase
    {
        private readonly PlanetService _planetService;

        public PlanetController(PlanetService planetService) 
        {
            _planetService = planetService;
        }

        [HttpGet("get-planet-location-by-name-and-date")]
        public IActionResult RequestPlanetLocationByNameAndDate(string name, DateTime dateTime) 
        {
            _planetService.RequestPlanetLocationByNameAndDateTime(name, dateTime);

            return Ok();
        }

        [HttpGet("get-current-planet-location-by-name")]
        public IActionResult RequestCurrentPlanetLocationByName(string name) 
        {
            _planetService.RequestPlanetLocationByNameAndDateTime(name, DateTime.Now.Date);

            return Ok();
        }
        
    }

}