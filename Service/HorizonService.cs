using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository;
using OurSolarSystemAPI.Utility;
namespace OurSolarSystemAPI.Service 
{
    public class HorizonService 
    {
        private readonly BarycenterRepository _barycenterRepo;
        private readonly PlanetRepository _planetRepo;
        private readonly ArtificialSatelliteRepository _artificialSatelitteRepo;

        public HorizonService(BarycenterRepository barycenterRepo, PlanetRepository planetRepo, ArtificialSatelliteRepository artificialSatelliteRepo) 
        {
             _barycenterRepo = barycenterRepo;
             _planetRepo = planetRepo;
             _artificialSatelitteRepo = artificialSatelliteRepo;
        }


        public async void ScrapeAndAddBarycentersToDB(HttpClient httpClient) 
        {
            var horizonScraper = new HorizonScraper();
            var horizonParser = new HorizonParser();
            List<Barycenter> barycenters = horizonScraper.BarycenterData();

            foreach (var barycenter in barycenters) 
            {
                var ephemeris = new List<EphemerisBarycenter>();
                string url = $"?format=text&COMMAND='{barycenter.HorizonId}'&center='@0'&ephem_type='Vectors'&vec_table=2&step_size=1d&start_time=2024-01-01&stop_time=2024-01-02";
                string apiResponse = await UtilityGetRequest.PerformRequest(url, httpClient);
                List<Dictionary<string, object>> vectors = horizonParser.ExtractEphemeris(apiResponse);
                
                foreach (var vector in vectors) 
                {
                    ephemeris.Add(EphemerisBarycenter.convertEphemerisDictToObject(vector, barycenter));
                }
                barycenter.Ephemeris = ephemeris;
                _barycenterRepo.CreateBarycenter(barycenter);
                
            }
        }

        public void AddHardcodedPlanetsToDB() 
        {
            var horizonScraper = new HorizonScraper();
            var planets = new List<Planet>
            {
                horizonScraper.MercuryData(),
                horizonScraper.VenusData(),
                horizonScraper.EarthData(),
                horizonScraper.MarsData(),
                horizonScraper.JupiterData(),
                horizonScraper.SaturnData(),
                horizonScraper.UranusData(),
                horizonScraper.NeptuneData(),
                horizonScraper.PlutoData()
            };

            foreach (var planet in planets) 
            {
                _planetRepo.CreatePlanet(planet);
            }

        }

        public async void ScrapeAndAddMoonsToDB(HttpClient httpClient) 
        {
            var horizonParser = new HorizonParser();
            List<MoonContainer> planets = MoonContainer.InstantiatePlanetAndMoonStructs();

            foreach (var planet in planets) 
            {
                var moons = new List<Moon>();
                foreach (var moonDesignators in planet.Moons) 
                {
                    string url = $"?format=text&COMMAND='{moonDesignators.ID}'&center='@0'&ephem_type='Vectors'&vec_table=2&step_size=1d&start_time=2024-01-01&stop_time=2024-01-02";
                    string apiResponse = await UtilityGetRequest.PerformRequest(url, httpClient);
                    Moon moon = horizonParser.ExtractMoonData(apiResponse);
                    var ephemeris = new List<EphemerisMoon>();
                    List<Dictionary<string, object>> vectorSets = horizonParser.ExtractEphemeris(apiResponse);

                    foreach (var vectorSet in vectorSets) 
                    {
                        ephemeris.Add(EphemerisMoon.convertEphemerisDictToObject(vectorSet, moon));
                    }
                    moon.Ephemeris = ephemeris;
                    moons.Add(moon);
                }
                _planetRepo.AddMoonsToExistingPlanet(moons, planet.HorizonPlanetId);
            }
        }

        public async void ScrapeAndAddArtificialSatellitesToDB(HttpClient httpClient) 
        {
            var celestrakScraper = new CelesTrakScraper();
            var n2yoScraper = new N2yoScraper();
            string urlStarlinkSatelittes = "https://celestrak.org/NORAD/elements/gp.php?GROUP=starlink&FORMAT=tle";

            List<ArtificialSatellite> satellites = celestrakScraper.ScrapeAndConvertTle(urlStarlinkSatelittes);
            foreach (var satellite in satellites) 
            {
                string url = $"https://www.n2yo.com/satellite/?s={satellite.NoradId}";
                string htmlContent = await UtilityGetRequest.PerformRequest(url, httpClient);
                Dictionary<string, string> scrapedSatelliteInfoN2yo = n2yoScraper.ExtractSatelliteInfoFromHtml(htmlContent);

                satellite.LaunchDate = scrapedSatelliteInfoN2yo["launchDate"];
                satellite.LaunchSite = scrapedSatelliteInfoN2yo["launchSite"];
                satellite.Period = scrapedSatelliteInfoN2yo["period"];
                satellite.Rcs = scrapedSatelliteInfoN2yo["rcs"];
                satellite.SemiMajorAxis = scrapedSatelliteInfoN2yo["semiMajorAxis"];
                satellite.Perigee = scrapedSatelliteInfoN2yo["perigee"];
                _artificialSatelitteRepo.AddSatellite(satellite);

            }

            



        }
    }
}