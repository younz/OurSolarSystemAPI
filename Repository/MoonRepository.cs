using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository
{
    public class MoonRepository 
    {
        private readonly OurSolarSystemContext _context;

        public MoonRepository(OurSolarSystemContext context) 
        {
            _context = context;
        }

        // public Moon RequestCurrentMoonLocationByHorizonId(int horizonId) 
        // {
        //     return _context.Moons
        //         .Where(m => m.HorizonId == horizonId)
        //         .Include(m => m.Ephemeris.Where(e => e.DateTime.Date == dateTime.Date))
        //         .FirstOrDefault();
        // }
    }

}