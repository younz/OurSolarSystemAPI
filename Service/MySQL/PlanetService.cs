using OurSolarSystemAPI.Repository.MySQL;
using OurSolarSystemAPI.Models;
namespace OurSolarSystemAPI.Service.MySQL
{
    public class PlanetService 
    {
        private readonly PlanetRepositoryMySQL _planetRepo;


        public PlanetService(PlanetRepositoryMySQL planetRepo) 
        {
            _planetRepo = planetRepo;
        }


        public List<Planet> requestAllPlanetsWithEphemeris() 
        {
            return _planetRepo.requestAllPlanetsWithEphemeris();
        }
    }
}