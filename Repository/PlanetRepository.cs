using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository {

    public class PlanetRepository() {

        public void CreatePlanet(OurSolarSystemContext context, Planet planet) 
        {
            context.Planets.Add(planet);
            context.SaveChanges();
        }

        public Planet RequestPlanetById(OurSolarSystemContext context, int planetId) 
        {
            return context.Planets.FirstOrDefault(p => p.Id == planetId) ?? throw new Exception($"No planet found with name: {planetId}");
        }

        public Planet RequestPlanetByName(OurSolarSystemContext context, string planetName) 
        {
            return context.Planets.FirstOrDefault(p => p.Name == planetName) ?? throw new Exception($"No planet found with name: {planetName}");
        }


        public void AddEphemerisToExistingPlanet(OurSolarSystemContext context, List<EphemerisPlanet> ephemeris, int planetId) 
        {
            var planet = context.Planets.FirstOrDefault(p => p.Id == planetId);
            if (planet != null)
            {
                foreach (var data in ephemeris) 
                {
                    planet.Ephemeris.Add(data);
                }
                context.SaveChanges();
            }
        }

        public void AddMoonsToExistingPlanet(OurSolarSystemContext context, List<Moon> moons, int planetId) 
        {
            var planet = context.Planets.FirstOrDefault(p => p.Id == planetId);
            if (planet != null)
            {
                foreach (var moon in moons) 
                {
                    planet.Moons.Add(moon);
                }
                context.SaveChanges();
            }
        }
    }

}