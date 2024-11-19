using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository {

    public class PlanetRepository() {

        public void CreatePlanet(OurSolarSystemContext context, Planet planet) 
        {
            context.Planets.Add(planet);
            context.SaveChanges();
        }

        public void AddMoonsToExistingPlanet(OurSolarSystemContext context, List<Moon> moons, int planetId) 
        {
            var planet = context.Planets.FirstOrDefault(p => p.ID == planetId);
            if (planet != null)
            {
                foreach (var moon in planet.Moons) 
                {
                    planet.Moons.Add(moon);
                }
                context.SaveChanges();
            }
        }
    }

}