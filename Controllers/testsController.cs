using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurSolarSystemAPI.Repository;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testsController(OurSolarSystemContext context) : ControllerBase
    {
        private readonly OurSolarSystemContext _context = context;

        // GET: api/planets
        [HttpGet]
        public ActionResult<IEnumerable<Planet>> GetPlanets()
        {
            return _context.Planets.ToList();
        }
    }
}
