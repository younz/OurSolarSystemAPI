using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository 
{

    public class PlanetRepository 
    {

        private readonly OurSolarSystemContext _context;

        public PlanetRepository(OurSolarSystemContext context) 
        {
            _context = context;
        }

        public void CreatePlanet(Planet planet) 
        {
            _context.Planets.Add(planet);
            _context.SaveChanges();
        }

        public Planet RequestPlanetById(int planetId) 
        {
            return _context.Planets.FirstOrDefault(p => p.Id == planetId) ?? throw new Exception($"No planet found with name: {planetId}");
        }

        public Planet RequestPlanetByName(string planetName) 
        {
            return _context.Planets.FirstOrDefault(p => p.Name == planetName) ?? throw new Exception($"No planet found with name: {planetName}");
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

        public void AddMoonsToExistingPlanet(List<Moon> moons, int planetId) 
        {
            var planet = _context.Planets.FirstOrDefault(p => p.Id == planetId);
            if (planet != null)
            {
                foreach (var moon in moons) 
                {
                    planet.Moons.Add(moon);
                }
                _context.SaveChanges();
            }
        }
    }

}