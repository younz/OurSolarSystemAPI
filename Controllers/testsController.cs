using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurSolarSystemAPI.Data;

namespace OurSolarSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testsController : ControllerBase
    {
        private readonly SolarSystemContext _context;

        public testsController(SolarSystemContext context)
        {
            _context = context;
        }

        // GET: api/planets
        [HttpGet]
        public ActionResult<IEnumerable<Planet>> GetPlanets()
        {
            return _context.Planets.ToList();
        }
    }
}
