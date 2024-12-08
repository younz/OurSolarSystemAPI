
using OurSolarSystemAPI.Repository;
namespace OurSolarSystemAPI.Service 
{
    public class MoonService 
    {
            private readonly PlanetRepositoryMySQL _planetRepo;

        public MoonService(PlanetRepositoryMySQL planetRepo) 
        {
             _planetRepo = planetRepo;
        }
        
    }
    
}