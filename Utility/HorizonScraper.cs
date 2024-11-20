using OurSolarSystemAPI.Models;
using System.Text.RegularExpressions;
namespace OurSolarSystemAPI.Utility
{
    public class HorizonScraper
    {

        public List<Dictionary<string, string>> ExtractEphemeris(string apiResponse)
        {
            List<Dictionary<string, string>> ephemerisData = new();

            Regex regexEphemerisSection = new Regex(@"\$\$SOE(.*?)\$\$EOE", RegexOptions.Singleline);
            Regex regexjulianDate = new Regex(@"(.*?)= A\.D\.");
            Regex regexdate = new Regex(@"= A\.D\. (.*?) 00:00");
    
            Regex regexPostionX = new Regex(@"X =(.*?)Y");
            Regex regexPostionY = new Regex(@"Y =(.*?)Z");
            Regex regexPostionZ = new Regex(@"Z =\s*(.+)");

            Regex regexVelocityX = new Regex(@"VX=(.*?)VY");
            Regex regexVelocityY = new Regex(@"VY=(.*?)VZ");
            Regex regexVelocityZ = new Regex(@"VZ=\s*(.+)");


            string ephemerisSection = regexEphemerisSection.Match(apiResponse).Groups[0].Value;
            Console.WriteLine(ephemerisSection);
            MatchCollection julianDates = regexjulianDate.Matches(ephemerisSection);
            MatchCollection dates = regexdate.Matches(ephemerisSection);

            MatchCollection positionsX = regexPostionX.Matches(ephemerisSection);
            MatchCollection positionsY = regexPostionY.Matches(ephemerisSection);
            MatchCollection positionsZ = regexPostionZ.Matches(ephemerisSection);

            MatchCollection velocitiesX = regexVelocityX.Matches(ephemerisSection);
            MatchCollection velocitiesY = regexVelocityY.Matches(ephemerisSection);
            MatchCollection velocitiesZ = regexVelocityZ.Matches(ephemerisSection);

            for (int i = 0; i < julianDates.Count; i++)
            {
                 var ephemerisDict = new Dictionary<string, string>
                {
                    { "julianDate", julianDates[i].Groups[1].Value.Trim() },
                    { "date", dates[i].Groups[1].Value.Trim() },
                    { "positionX", positionsX[i].Groups[1].Value.Trim() },
                    { "positionY", positionsY[i].Groups[1].Value.Trim() },
                    { "positonZ", positionsZ[i].Groups[1].Value.Trim() },
                    { "velocityX", velocitiesX[i].Groups[1].Value.Trim() },
                    { "velocityY", velocitiesY[i].Groups[1].Value.Trim() },
                    { "velocityZ", velocitiesZ[i].Groups[1].Value.Trim() }
                };
                ephemerisData.Add(ephemerisDict);


            }
            return ephemerisData;
        }

        public Dictionary<string, string> ExtractMoonData(string apiResponse)
        {
            Regex regexMoonName = new Regex(@"Target body name:(.*?){source:");
            Regex regexAllMoonAttributes = new Regex(@"\*{5,}([\s\S]*?)\*{5,}");
            Regex regexMeanRadius = new Regex(@"Mean radius.*?=(.*?)Density");
            Regex regexDensity = new Regex(@"Density.*?=\s*(.+)");
            Regex regexGM = new Regex(@"GM.*?=(.*?)Geometric Albedo");
            Regex regexGeometricAlbedo = new Regex(@"Geometric Albedo.*?=\s*(.+)");
            Regex regexSemiMajorAxis = new Regex(@"Semi-major axis.*?~(.*?)Orbital period");
            Regex regexOrbitalPeriod = new Regex(@"Orbital period.*?~\s*(.+)");
            Regex regexEccentricity = new Regex(@"Eccentricity.*?~(.*?)Rotational period");
            Regex regexRotationalPeriod = new Regex(@"Rotational period.*?=\s*(.+)");
            Regex regexInclination = new Regex(@"Inclination.*?~\s*(.+)");

            string moonName = regexMoonName.Match(apiResponse).Groups[1].Value.Trim();
            string moonAttributes = regexAllMoonAttributes.Match(apiResponse).Groups[0].Value.Trim();
            string meanRadius = regexMeanRadius.Match(moonAttributes).Groups[1].Value.Trim();
            string density = regexDensity.Match(moonAttributes).Groups[1].Value.Trim();
            string gm = regexGM.Match(moonAttributes).Groups[1].Value.Trim();
            string geometricAlbedo = regexGeometricAlbedo.Match(moonAttributes).Groups[1].Value.Trim();
            string semiMajorAxis = regexSemiMajorAxis.Match(moonAttributes).Groups[1].Value.Trim();
            string orbitalPeriod = regexOrbitalPeriod.Match(moonAttributes).Groups[1].Value.Trim();
            string eccentricity = regexEccentricity.Match(moonAttributes).Groups[1].Value.Trim();
            string rotationalPeriod = regexRotationalPeriod.Match(moonAttributes).Groups[1].Value.Trim();
            string inclination = regexInclination.Match(moonAttributes).Groups[1].Value.Trim();

            return new Dictionary<string, string>
        {
            { "name", moonName },
            { "meanRadius", meanRadius },
            { "density", density },
            { "gm", gm },
            { "geometricAlbedo", geometricAlbedo },
            { "semiMajorAxis", semiMajorAxis },
            { "orbitalPeriod", orbitalPeriod },
            { "eccentricity", eccentricity },
            { "rotationalPeriod", rotationalPeriod },
            { "inclination", inclination }
        };

        }

        public Planet MercuryData()
        {
            return new Planet(
                    horizonId: 199,
                    barycenterId: 0,
                    barycenter: null, // Assuming no barycenter for Mercury in this example
                    name: "Mercury",
                    volumeMeanRadius: "2439.4±0.1",
                    density: "5.427",
                    mass: "3.302",
                    volume: "6.085",
                    equatorialRadius: "2440.53",
                    siderealRotationPeriod: "58.6463",
                    siderealRotationRate: "0.00000124001",
                    meanSolarDay: "175.9421",
                    polarGravity: null, // Not provided in the data
                    equatorialGravity: "3.701",
                    geometricAlbedo: "0.106",
                    massRatioToSun: "6023682",
                    meanTemperature: "440",
                    atmosphericPressure: "< 5x10^-15",
                    obliquityToOrbit: "2.11' ± 0.1'",
                    maxAngularDiameter: "11.0\"",
                    meanSideRealOrbitalPeriod: "87.969257",
                    orbitalSpeed: "47.362",
                    hillsSphereRadius: "94.4",
                    escapeSpeed: "4.435",
                    gravitationalParameter: "22031.86855",
                    moons: null, // Assuming no moons for Mercury
                    ephemeris: null, // Assuming no ephemeris data provided
                    solarConstantPerihelion: "14462",
                    solarConstantAphelion: "6278",
                    solarConstantMean: "9126",
                    maxPlanetaryIRPerihelion: "12700",
                    maxPlanetaryIRAphelion: "5500",
                    maxPlanetaryIRMean: "8000",
                    minPlanetaryIRPerihelion: "6",
                    minPlanetaryIRAphelion: "6",
                    minPlanetaryIRMean: "6"
                );
        }

        public Planet VenusData()
        {
            return new Planet(
                    horizonId: 299, // Assuming Horizon ID corresponds to "id"
                    barycenterId: 0, // Assuming no barycenter for Venus
                    barycenter: null, // Assuming no barycenter object provided
                    name: "Venus",
                    volumeMeanRadius: "6051.84 ± 0.01",
                    density: "5.204",
                    mass: "48.685",
                    volume: "92.843",
                    equatorialRadius: "6051.893",
                    siderealRotationPeriod: "243.018484",
                    siderealRotationRate: "-0.00000029924",
                    meanSolarDay: "116.7490",
                    polarGravity: null, // Not provided
                    equatorialGravity: "8.870",
                    geometricAlbedo: "0.65",
                    massRatioToSun: "408523.72",
                    meanTemperature: "735",
                    atmosphericPressure: "90",
                    obliquityToOrbit: "177.3",
                    maxAngularDiameter: "60.2\"",
                    meanSideRealOrbitalPeriod: "224.70079922",
                    orbitalSpeed: "35.021",
                    hillsSphereRadius: "167.1",
                    escapeSpeed: "10.361",
                    gravitationalParameter: "324858.592",
                    moons: null, // Assuming no moons for Venus
                    ephemeris: null, // Assuming no ephemeris data provided
                    solarConstantPerihelion: "2759",
                    solarConstantAphelion: "2614",
                    solarConstantMean: "2650",
                    maxPlanetaryIRPerihelion: "153",
                    maxPlanetaryIRAphelion: "153",
                    maxPlanetaryIRMean: "153",
                    minPlanetaryIRPerihelion: "153",
                    minPlanetaryIRAphelion: "153",
                    minPlanetaryIRMean: "153"
                );

        }


        public Planet EarthData()
        {
            return new Planet(
                    horizonId: 399, // Assuming Horizon ID corresponds to "id"
                    barycenterId: 0, // Assuming no barycenter for Earth
                    barycenter: null, // Assuming no barycenter object provided
                    name: "Earth",
                    volumeMeanRadius: "3389.92 ± 0.04",
                    density: "3.933 (5 ± 4)",
                    mass: "6.4171",
                    volume: "16.318",
                    equatorialRadius: "3396.19",
                    siderealRotationPeriod: "24.622962",
                    siderealRotationRate: "0.0000708822",
                    meanSolarDay: "88775.24415",
                    polarGravity: "3.758",
                    equatorialGravity: "3.71",
                    geometricAlbedo: "0.150",
                    massRatioToSun: "3098703.59",
                    meanTemperature: "210",
                    atmosphericPressure: "0.0056",
                    obliquityToOrbit: "25.19",
                    maxAngularDiameter: "17.9\"",
                    meanSideRealOrbitalPeriod: "686.98",
                    orbitalSpeed: "24.13",
                    hillsSphereRadius: "319.8",
                    escapeSpeed: "5.027",
                    gravitationalParameter: "42828.375214",
                    moons: null, // Assuming no moons for Earth
                    ephemeris: null, // Assuming no ephemeris data provided
                    solarConstantPerihelion: "717",
                    solarConstantAphelion: "493",
                    solarConstantMean: "589",
                    maxPlanetaryIRPerihelion: "470",
                    maxPlanetaryIRAphelion: "315",
                    maxPlanetaryIRMean: "390",
                    minPlanetaryIRPerihelion: "30",
                    minPlanetaryIRAphelion: "30",
                    minPlanetaryIRMean: "30"
                );

        }

        public Planet MarsData()
        {
            return new Planet(
                horizonId: 499, // Assuming Horizon ID corresponds to "id"
                barycenterId: 0, // Assuming no barycenter for Mars
                barycenter: null, // Assuming no barycenter object provided
                name: "Mars",
                volumeMeanRadius: "3389.92 ± 0.04",
                density: "3.933(5 ± 4)",
                mass: "6.4171",
                volume: "16.318",
                equatorialRadius: "3396.19",
                siderealRotationPeriod: "24.622962",
                siderealRotationRate: "0.0000708822",
                meanSolarDay: "88775.24415",
                polarGravity: "3.758",
                equatorialGravity: "3.71",
                geometricAlbedo: "0.150",
                massRatioToSun: "3098703.59",
                meanTemperature: "210",
                atmosphericPressure: "0.0056",
                obliquityToOrbit: "25.19",
                maxAngularDiameter: "17.9\"",
                meanSideRealOrbitalPeriod: "686.98",
                orbitalSpeed: "24.13",
                hillsSphereRadius: "319.8",
                escapeSpeed: "5.027",
                gravitationalParameter: "42828.375214",
                moons: null, // Assuming no moons for Mars
                ephemeris: null, // Assuming no ephemeris data provided
                solarConstantPerihelion: "717",
                solarConstantAphelion: "493",
                solarConstantMean: "589",
                maxPlanetaryIRPerihelion: "470",
                maxPlanetaryIRAphelion: "315",
                maxPlanetaryIRMean: "390",
                minPlanetaryIRPerihelion: "30",
                minPlanetaryIRAphelion: "30",
                minPlanetaryIRMean: "30"
            );

        }

        public Planet JupiterData()
        {
            return new Planet(
                horizonId: 599,
                barycenterId: 0,
                barycenter: null,
                name: "Jupiter",
                volumeMeanRadius: "69911 ± 6",
                density: "1.3262 ± 0.0003",
                mass: "189818722 ± 8817",
                volume: null,
                equatorialRadius: "71492 ± 4",
                siderealRotationPeriod: "~9.9259",
                siderealRotationRate: "0.00017585",
                meanSolarDay: "~9.9259",
                polarGravity: "28.34",
                equatorialGravity: "24.79",
                geometricAlbedo: "0.52",
                massRatioToSun: null,
                meanTemperature: "165 ± 5",
                atmosphericPressure: null,
                obliquityToOrbit: "3.13",
                maxAngularDiameter: null,
                meanSideRealOrbitalPeriod: "4332.589",
                orbitalSpeed: "13.0697",
                hillsSphereRadius: "740",
                escapeSpeed: "59.5",
                gravitationalParameter: "126686531.900",
                moons: null,
                ephemeris: null,
                solarConstantPerihelion: "56",
                solarConstantAphelion: "46",
                solarConstantMean: "51",
                maxPlanetaryIRPerihelion: "13.7",
                maxPlanetaryIRAphelion: "13.4",
                maxPlanetaryIRMean: "13.6",
                minPlanetaryIRPerihelion: "13.7",
                minPlanetaryIRAphelion: "13.4",
                minPlanetaryIRMean: "13.6"
                );
        }


        public Planet SaturnData()
        {
            return new Planet(
                horizonId: 699, // Assuming Horizon ID corresponds to "id"
                barycenterId: 0, // Assuming no barycenter for Saturn
                barycenter: null, // Assuming no barycenter object provided
                name: "Saturn",
                volumeMeanRadius: "58232 ± 6",
                density: "0.687 ± 0.001",
                mass: "5.6834",
                volume: null, // No volume data provided
                equatorialRadius: "60268 ± 4",
                siderealRotationPeriod: "~10.656",
                siderealRotationRate: "0.000163785",
                meanSolarDay: "~10.656",
                polarGravity: "12.14 ± 0.01",
                equatorialGravity: "10.44",
                geometricAlbedo: "0.47",
                massRatioToSun: null, // No ratio provided
                meanTemperature: "134 ± 4",
                atmosphericPressure: null, // No atmospheric pressure data provided
                obliquityToOrbit: "26.73",
                maxAngularDiameter: null, // No angular diameter data provided
                meanSideRealOrbitalPeriod: "10755.698",
                orbitalSpeed: "9.68",
                hillsSphereRadius: "1100",
                escapeSpeed: "35.5",
                gravitationalParameter: "37931206.234",
                moons: null, // Assuming no moons for Saturn
                ephemeris: null, // Assuming no ephemeris data provided
                solarConstantPerihelion: "16.8",
                solarConstantAphelion: "13.6",
                solarConstantMean: "15.1",
                maxPlanetaryIRPerihelion: "4.7",
                maxPlanetaryIRAphelion: "4.5",
                maxPlanetaryIRMean: "4.6",
                minPlanetaryIRPerihelion: "4.7",
                minPlanetaryIRAphelion: "4.5",
                minPlanetaryIRMean: "4.6"
            );
        }

        public Planet UranusData()
        {
            return new Planet(
                horizonId: 799, // Assuming Horizon ID corresponds to "id"
                barycenterId: 0, // Assuming no barycenter for Uranus
                barycenter: null, // Assuming no barycenter object provided
                name: "Uranus",
                volumeMeanRadius: "25362 ± 12",
                density: "1.271",
                mass: "86.813",
                volume: null, // No volume data provided
                equatorialRadius: "25559 ± 4",
                siderealRotationPeriod: "~17.24",
                siderealRotationRate: "-0.000101237",
                meanSolarDay: "~17.24",
                polarGravity: "9.19 ± 0.02",
                equatorialGravity: "8.87",
                geometricAlbedo: "0.51",
                massRatioToSun: null, // No ratio provided
                meanTemperature: "76 ± 2",
                atmosphericPressure: null, // No atmospheric pressure data provided
                obliquityToOrbit: "97.77",
                maxAngularDiameter: null, // No angular diameter data provided
                meanSideRealOrbitalPeriod: "30685.4",
                orbitalSpeed: "6.8",
                hillsSphereRadius: "2700",
                escapeSpeed: "21.3",
                gravitationalParameter: "5793951.256",
                moons: null, // Assuming no moons for Uranus
                ephemeris: null, // Assuming no ephemeris data provided
                solarConstantPerihelion: "4.09",
                solarConstantAphelion: "3.39",
                solarConstantMean: "3.71",
                maxPlanetaryIRPerihelion: "0.72",
                maxPlanetaryIRAphelion: "0.55",
                maxPlanetaryIRMean: "0.63",
                minPlanetaryIRPerihelion: "0.72",
                minPlanetaryIRAphelion: "0.55",
                minPlanetaryIRMean: "0.63"
            );
        }

        public Planet NeptuneData()
        {
            return new Planet(
                horizonId: 899, // Assuming Horizon ID corresponds to "id"
                barycenterId: 0, // Assuming no barycenter for Neptune
                barycenter: null, // Assuming no barycenter object provided
                name: "Neptune",
                volumeMeanRadius: "24624 ± 21",
                density: "1.638",
                mass: "102.409",
                volume: "6254",
                equatorialRadius: "24766 ± 15",
                siderealRotationPeriod: "~16.11",
                siderealRotationRate: "0.000108338",
                meanSolarDay: "~16.11",
                polarGravity: "11.41 ± 0.03",
                equatorialGravity: "11.15",
                geometricAlbedo: "0.41",
                massRatioToSun: null, // No ratio provided
                meanTemperature: "72 ± 2",
                atmosphericPressure: null, // No atmospheric pressure data provided
                obliquityToOrbit: "28.32",
                maxAngularDiameter: null, // No angular diameter data provided
                meanSideRealOrbitalPeriod: "60189",
                orbitalSpeed: "5.43",
                hillsSphereRadius: "4700",
                escapeSpeed: "23.5",
                gravitationalParameter: "6835099.97",
                moons: null, // Assuming no moons for Neptune
                ephemeris: null, // Assuming no ephemeris data provided
                solarConstantPerihelion: "1.54",
                solarConstantAphelion: "1.49",
                solarConstantMean: "1.51",
                maxPlanetaryIRPerihelion: "0.52",
                maxPlanetaryIRAphelion: "0.52",
                maxPlanetaryIRMean: "0.52",
                minPlanetaryIRPerihelion: "0.52",
                minPlanetaryIRAphelion: "0.52",
                minPlanetaryIRMean: "0.52"
            );

        }

        public Planet PlutoData()
        {
            return new Planet(
                horizonId: 999, // Assuming Horizon ID corresponds to "id"
                barycenterId: 0, // Assuming no barycenter for Pluto
                barycenter: null, // Assuming no barycenter object provided
                name: "Pluto",
                volumeMeanRadius: "1188.3 ± 1.6",
                density: "1.86",
                mass: "1.307 ± 0.018",
                volume: "0.697",
                equatorialRadius: null, // Not provided
                siderealRotationPeriod: "153.29335198",
                siderealRotationRate: "0.0000113856",
                meanSolarDay: "153.2820",
                polarGravity: "0.611",
                equatorialGravity: null, // Not provided
                geometricAlbedo: null, // Not provided
                massRatioToSun: "0.122", // Ratio of mass to sun
                meanTemperature: null, // Not provided
                atmosphericPressure: null, // Not provided
                obliquityToOrbit: null, // Not provided
                maxAngularDiameter: null, // Not provided
                meanSideRealOrbitalPeriod: "249.58932", // Sidereal orbit period in years
                orbitalSpeed: "4.67", // Mean orbit velocity in km/s
                hillsSphereRadius: null, // Not provided
                escapeSpeed: "1.21", // Escape speed in km/s
                gravitationalParameter: "869.326",
                moons: null, // Assuming no moons for Pluto
                ephemeris: null, // Assuming no ephemeris data provided
                solarConstantPerihelion: "1.56",
                solarConstantAphelion: "0.56",
                solarConstantMean: "0.88",
                maxPlanetaryIRPerihelion: "0.8",
                maxPlanetaryIRAphelion: "0.3",
                maxPlanetaryIRMean: "0.5",
                minPlanetaryIRPerihelion: "0.8",
                minPlanetaryIRAphelion: "0.3",
                minPlanetaryIRMean: "0.5"
            );

        }

        public void moonIdentifiersForGetRequests() 
        {
            

        }

    }
}
