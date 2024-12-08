using HtmlAgilityPack;
using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository;

namespace OurSolarSystemAPI.Service 
{
    public class PlanetService 
    {
        private readonly PlanetRepositoryMySQL _planetRepo;

        public PlanetService(PlanetRepositoryMySQL planetRepo) 
        {
             _planetRepo = planetRepo;
        }

        public Planet? RequestPlanetLocationByNameAndDateTime(string name, DateTime dateTime) 
        {
            return _planetRepo.RequestPlanetLocationByNameAndDateTime(name, dateTime);
        }
        
    }
    
}