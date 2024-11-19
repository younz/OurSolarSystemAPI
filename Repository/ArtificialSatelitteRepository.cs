using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository;

namespace OurSolarSystemAPI.Repository {

    public class ArtificialSatelliteRepository() {

        public void CreatePlanet(OurSolarSystemContext context, Planet planet) 
        {
            context.Planets.Add(planet);
            context.SaveChanges();
        }
    }

}