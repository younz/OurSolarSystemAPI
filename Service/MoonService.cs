
using OurSolarSystemAPI.Repository;
namespace OurSolarSystemAPI.Service 
{
    public class MoonService 
    {
            private readonly PlanetRepository _planetRepo;

        public MoonService(PlanetRepository planetRepo) 
        {
             _planetRepo = planetRepo;
        }
        
    }
    
}