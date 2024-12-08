using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository.MySQL  
{
    public class BarycenterRepositoryMySQL
    {
        private readonly OurSolarSystemContext _context;

        public BarycenterRepositoryMySQL(OurSolarSystemContext context) 
        {
            _context = context;
        }

        public void CreateBarycenter(Barycenter barycenter) 
        {
            _context.Barycenters.Add(barycenter);
            _context.SaveChanges();
        }

        public Barycenter? RequestBarycenterLocationByNameAndDateTime(string name, DateTime dateTime)
        {
            return _context.Barycenters
                .Where(b => b.Name == name)
                .Include(b => b.Ephemeris.Where(e => e.DateTime.Date == dateTime.Date))
                .FirstOrDefault();
        }

        public Barycenter? RequestBarycenterLocationByHorizonIdAndDateTime(int horizonId, DateTime dateTime)
        {
            return _context.Barycenters
                .Where(b => b.HorizonId == horizonId)
                .Include(b => b.Ephemeris.Where(e => e.DateTime.Date == dateTime.Date))
                .FirstOrDefault();
        }

    }



}