using HtmlAgilityPack;
using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository;

namespace OurSolarSystemAPI.Service 
{
    public class PlanetService 
    {
        private readonly PlanetRepository _planetRepo;

        public PlanetService(PlanetRepository planetRepo) 
        {
             _planetRepo = planetRepo;
        }

        public Planet? RequestPlanetLocationByNameAndDateTime(string name, DateTime dateTime) 
        {
            return _planetRepo.RequestPlanetLocationByNameAndDateTime(name, dateTime);
        }
        
    }
    
}