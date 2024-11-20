using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository;

namespace OurSolarSystemAPI.Repository {

    public class ArtificialSatelliteRepository() {

        public void CreatePlanet(OurSolarSystemContext context, ArtificialSatellite satellite) 
        {
            context.ArtificialSatellites.Add(satellite);
            context.SaveChanges();
        }

        public void AddEphemerisToExistingSatellite(OurSolarSystemContext context, List<EphemerisArtificialSatellite> ephemeris, int satelliteId) 
        {
            var satellite = context.ArtificialSatellites.FirstOrDefault(s => s.Id == satelliteId);
            if (satellite != null)
            {
                foreach (var data in ephemeris) 
                {
                    satellite.Ephemeris.Add(data);
                }
                context.SaveChanges();
            }
        }
    }

}