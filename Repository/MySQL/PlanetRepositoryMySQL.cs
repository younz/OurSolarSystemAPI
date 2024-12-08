using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository.MySQL 
{

    public class PlanetRepositoryMySQL 
    {

        private readonly OurSolarSystemContext _context;

        public PlanetRepositoryMySQL(OurSolarSystemContext context) 
        {
            _context = context;
        }

        public void CreatePlanet(Planet planet) 
        {
            _context.Planets.Add(planet);
            _context.SaveChanges();
        }

        public List<Planet> requestAllPlanetsWithEphemeris() 
        {
            return _context.Planets
            .Include(p => p.Ephemeris)
            .ToList();
        }

        public Planet? RequestPlanetById(int horizonId) 
        {
            return _context.Planets.FirstOrDefault(p => p.HorizonId == horizonId);
        }

        public Planet? RequestPlanetLocationByNameAndDateTime(string name, DateTime dateTime)
        {
            return _context.Planets
                .Where(p => p.Name == name)
                .Include(p => p.Ephemeris.Where(e => e.DateTime.Date == dateTime.Date))
                .FirstOrDefault();
        }

        public Planet? RequestPlanetByName(string planetName) 
        {
            return _context.Planets.FirstOrDefault(p => p.Name == planetName);
        }


        public void AddEphemerisToExistingPlanet(List<EphemerisPlanet> ephemeris, int horizonId) 
        {
            var planet = _context.Planets.FirstOrDefault(p => p.HorizonId == horizonId);
            if (planet != null)
            {
                foreach (var data in ephemeris) 
                {
                    planet.Ephemeris.Add(data);
                }
                _context.SaveChanges();
            }
        }

        public void AddMoonsToExistingPlanet(List<Moon> moons, int horizonId) 
        {
            var planet = _context.Planets.FirstOrDefault(p => p.HorizonId == horizonId);
            if (planet != null)
            {
                if (planet.Moons == null)
                {
                    planet.Moons = new List<Moon>();
                }

                planet.Moons.AddRange(moons);
                _context.SaveChanges();
            }
        }
    }

}