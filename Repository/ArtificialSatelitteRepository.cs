using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository;

namespace OurSolarSystemAPI.Repository {

    public class ArtificialSatelliteRepository 
    {
        private readonly OurSolarSystemContext _context;

        public ArtificialSatelliteRepository(OurSolarSystemContext context) 
        {
            _context = context;
        }

        public void AddSatellite(ArtificialSatellite satellite) 
        {
            _context.ArtificialSatellites.Add(satellite);
            _context.SaveChanges();
        }

        public ArtificialSatellite? RequestSatelitteByNoradId(int noradId) 
        {
            return _context.ArtificialSatellites.FirstOrDefault(s => s.NoradId == noradId);
        }

        public ArtificialSatellite? RequestSatelliteLocationByNoradIdAndDateTime(int noradId, DateTime dateTime)
        {
            return _context.ArtificialSatellites
                .Where(s => s.NoradId == noradId)
                .Include(s => s.Tle.Where(t => t.IsArchived == false))
                .FirstOrDefault();
        }

        // public void AddEphemerisToExistingSatellite(OurSolarSystemContext context, List<EphemerisArtificialSatellite> ephemeris, int satelliteId) 
        // {
        //     var satellite = context.ArtificialSatellites.FirstOrDefault(s => s.Id == satelliteId);
        //     if (satellite != null)
        //     {
        //         foreach (var data in ephemeris) 
        //         {
        //             satellite.Ephemeris.Add(data);
        //         }
        //         context.SaveChanges();
        //     }
        // }
    }

}