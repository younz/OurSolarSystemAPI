using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository 
{
    public class BarycenterRepository
    {
        private readonly OurSolarSystemContext _context;

        public BarycenterRepository(OurSolarSystemContext context) 
        {
            _context = context;
        }

        public void CreateBarycenter(Barycenter barycenter) 
        {
            _context.Barycenters.Add(barycenter);
            _context.SaveChanges();
        }
    }



}