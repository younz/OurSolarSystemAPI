using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;

namespace OurSolarSystemAPI.Data
{
    public class SolarSystemContext : DbContext
    {
        public SolarSystemContext(DbContextOptions<SolarSystemContext> options)
        : base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>(entity =>
            {
                entity.HasKey(e => e.PlanetID);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });
        }
    }

    //for test purposes 
    public class Planet
    {
        public int PlanetID { get; set; }
        public string Name { get; set; }
        public float DiameterKm { get; set; }
        public float DistanceFromSunKm { get; set; }
        public int NumberOfMoons { get; set; }
    }
}
