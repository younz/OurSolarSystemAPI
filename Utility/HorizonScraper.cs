
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Data.Common;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;
namespace OurSolarSystemAPI.Utility
{
    public class HorizonScraper
    {

        public List<Dictionary<string, string>> extractEphemeris(string apiResponse)
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

        public Dictionary<string, string> extractMoonData(string apiResponse)
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

        public void mercuryData()
        {
            string id = "199";
            string volMeanRadiusKm = "2439.4±0.1";
            string vensityGCm3 = "5.427";
            string vassX10_23Kg = "3.302";
            string volumeX10_10Km3 = "6.085";
            string siderealRotPeriodDays = "58.6463";
            string sidRotRateRadPerS = "0.00000124001";
            string meanSolarDayDays = "175.9421";
            string coreRadiusKm = "~1600";
            string ceometricAlbedo = "0.106";
            string surfaceEmissivity = "0.77±0.06";
            string gmKm3PerS2 = "22031.86855";
            string equatorialRadiusReKm = "2440.53";
            string gm1SigmaKm3PerS2 = "";
            string massRatioSunPlanet = "6023682";
            string momentOfInertia = "0.33";
            string equatorialGravityMS2 = "3.701";
            string atmosphericPressureBar = "< 5x10^-15";
            string maxAngularDiameterArcSec = "11.0\"";
            string meanTemperatureK = "440";
            string visualMagV_1_0 = "-0.42";
            string obliquityToOrbit = "2.11' ± 0.1'";
            string hillsSphereRadiusRp = "94.4";
            string siderealOrbitalPeriodYears = "0.2408467";
            string meanOrbitVelocityKmPerS = "47.362";
            string siderealOrbitalPeriodDays = "87.969257";
            string escapeVelocityKmPerS = "4.435";

            string solarConstantPerihelionWPerM2 = "14462";
            string solarConstantAphelionWPerM2 = "6278";
            string solarConstantMeanWPerM2 = "9126";

            string maxPlanetaryIRPerihelionWPerM2 = "12700";
            string maxPlanetaryIRAphelionWPerM2 = "5500";
            string maxPlanetaryIRMeanWPerM2 = "8000";

            string minPlanetaryIRPerihelionWPerM2 = "6";
            string minPlanetaryIRAphelionWPerM2 = "6";
            string minPlanetaryIRMeanWPerM2 = "6";
        }

        public void venusData()
        {
            string id = "299";
            string volMeanRadiusKm = "6051.84 ± 0.01";
            string densityGCm3 = "5.204";
            string massX10_23Kg = "48.685";
            string volumeX10_10Km3 = "92.843";
            string siderealRotPeriodDays = "243.018484";
            string siderealRotRateRadPerS = "-0.00000029924";
            string meanSolarDayDays = "116.7490";
            string equatorialGravityMS2 = "8.870";
            string momentOfInertia = "0.33";
            string coreRadiusKm = "~3200";
            string geometricAlbedo = "0.65";
            string potentialLoveK2 = "~0.25";
            string gmKm3PerS2 = "324858.592";
            string equatorialRadiusKm = "6051.893";
            string gm1SigmaKm3PerS2 = "±0.006";
            string massRatioSunVenus = "408523.72";
            string atmosphericPressureBar = "90";
            string maxAngularDiameterInches = "60.2\"";
            string meanTemperatureK = "735";
            string visualMagnitudeV1_0 = "-4.40";
            string obliquityToOrbitDeg = "177.3";
            string hillsSphereRadiusRp = "167.1";
            string siderealOrbPeriodYears = "0.61519726";
            string orbitSpeedKmPerS = "35.021";
            string siderealOrbPeriodDays = "224.70079922";
            string escapeSpeedKmPerS = "10.361";

            string solarConstantPerihelionWPerM2 = "2759";
            string solarConstantAphelionWPerM2 = "2614";
            string solarConstantMeanWPerM2 = "2650";

            string maxPlanetaryIRPerihelionWPerM2 = "153";
            string maxPlanetaryIRAphelionWPerM2 = "153";
            string maxPlanetaryIRMeanWPerM2 = "153";

            string minPlanetaryIRPerihelionWPerM2 = "153";
            string minPlanetaryIRAphelionWPerM2 = "153";
            string minPlanetaryIRMeanWPerM2 = "153";

        }


        public void earthData()
        {
            string id = "399";
            string volMeanRadiusKm = "3389.92 ± 0.04";
            string densityGCm3 = "3.933 (5 ± 4)";
            string massX10_23Kg = "6.4171";
            string flatteningF = "1/169.779";
            string volumeX10_10Km3 = "16.318";
            string equatorialRadiusKm = "3396.19";
            string siderealRotPeriodHours = "24.622962";
            string siderealRotRateRadPerS = "0.0000708822";
            string meanSolarDaySol = "88775.24415";
            string polarGravityMS2 = "3.758";
            string coreRadiusKm = "~1700";
            string equatorialGravityMS2 = "3.71";
            string geometricAlbedo = "0.150";
            string gmKm3PerS2 = "42828.375214";
            string massRatioSunMars = "3098703.59";
            string gm1SigmaKm3PerS2 = "± 0.00028";
            string massOfAtmosphereKg = "~ 2.5 x 10^16";
            string meanTemperatureK = "210";
            string atmosphericPressureBar = "0.0056";
            string obliquityToOrbitDeg = "25.19";
            string maxAngularDiameterInches = "17.9\"";
            string meanSiderealOrbPeriodYears = "1.88081578";
            string visualMagnitudeV1_0 = "-1.52";
            string meanSiderealOrbPeriodDays = "686.98";
            string orbitalSpeedKmPerS = "24.13";
            string hillsSphereRadiusRp = "319.8";
            string escapeSpeedKmPerS = "5.027";

            string solarConstantPerihelionWPerM2 = "717";
            string solarConstantAphelionWPerM2 = "493";
            string solarConstantMeanWPerM2 = "589";

            string maxPlanetaryIRPerihelionWPerM2 = "470";
            string maxPlanetaryIRAphelionWPerM2 = "315";
            string maxPlanetaryIRMeanWPerM2 = "390";

            string minPlanetaryIRPerihelionWPerM2 = "30";
            string minPlanetaryIRAphelionWPerM2 = "30";
            string minPlanetaryIRMeanWPerM2 = "30";

        }

        public void marsData()
        {
            string id = "499";
            string volMeanRadiusKm = "3389.92 ± 0.04";
            string densityGCm3 = "3.933(5 ± 4)";
            string massX10_23Kg = "6.4171";
            string flatteningF = "1/169.779";
            string volumeX10_10Km3 = "16.318";
            string equatorialRadiusKm = "3396.19";
            string siderealRotPeriodHours = "24.622962";
            string siderealRotRateRadPerS = "0.0000708822";
            string meanSolarDaySol = "88775.24415";
            string polarGravityMS2 = "3.758";
            string coreRadiusKm = "~1700";
            string equatorialGravityMS2 = "3.71";
            string geometricAlbedo = "0.150";
            string gmKm3PerS2 = "42828.375214";
            string massRatioSunMars = "3098703.59";
            string gm1SigmaKm3PerS2 = "± 0.00028";
            string massOfAtmosphereKg = "~ 2.5 x 10^16";
            string meanTemperatureK = "210";
            string atmosphericPressureBar = "0.0056";
            string obliquityToOrbitDeg = "25.19";
            string maxAngularDiameterInches = "17.9\"";
            string meanSiderealOrbPeriodYears = "1.88081578";
            string visualMagnitudeV1_0 = "-1.52";
            string meanSiderealOrbPeriodDays = "686.98";
            string orbitalSpeedKmPerS = "24.13";
            string hillsSphereRadiusRp = "319.8";
            string escapeSpeedKmPerS = "5.027";

            string solarConstantPerihelionWPerM2 = "717";
            string solarConstantAphelionWPerM2 = "493";
            string solarConstantMeanWPerM2 = "589";

            string maxPlanetaryIRPerihelionWPerM2 = "470";
            string maxPlanetaryIRAphelionWPerM2 = "315";
            string maxPlanetaryIRMeanWPerM2 = "390";

            string minPlanetaryIRPerihelionWPerM2 = "30";
            string minPlanetaryIRAphelionWPerM2 = "30";
            string minPlanetaryIRMeanWPerM2 = "30";

        }

        public void jupiterData()
        {
            string id = "599";
            string massX10_22G = "189818722 ± 8817";
            string densityGCm3 = "1.3262 ± 0.0003";
            string equatorialRadius1BarKm = "71492 ± 4";
            string polarRadiusKm = "66854 ± 10";
            string volMeanRadiusKm = "69911 ± 6";
            string flattening = "0.06487";
            string geometricAlbedo = "0.52";
            string rockyCoreMassMcM = "0.0261";
            string siderealRotPeriodIII = "9h 55m 29.711s";
            string siderealRotRateRadPerS = "0.00017585";
            string meanSolarDayHrs = "~9.9259";
            string gmKm3PerS2 = "126686531.900";
            string gm1SigmaKm3PerS2 = "± 1.2732";
            string equatorialGravityGeMS2 = "24.79";
            string polarGravityGpMS2 = "28.34";
            string visualMagnitudeV1_0 = "-9.40";
            string visualMagnitudeOpposition = "-2.70";
            string obliquityToOrbitDeg = "3.13";
            string siderealOrbitPeriodYears = "11.861982204";
            string siderealOrbitPeriodDays = "4332.589";
            string meanDailyMotionDegPerDay = "0.0831294";
            string meanOrbitSpeedKmPerS = "13.0697";
            string atmosphericTemperature1BarK = "165 ± 5";
            string escapeSpeedKmPerS = "59.5";
            string rocheLimitIceRp = "2.76";
            string hillsSphereRadiusRp = "740";

            string solarConstantPerihelionWPerM2 = "56";
            string solarConstantAphelionWPerM2 = "46";
            string solarConstantMeanWPerM2 = "51";

            string maxPlanetaryIRPerihelionWPerM2 = "13.7";
            string maxPlanetaryIRAphelionWPerM2 = "13.4";
            string maxPlanetaryIRMeanWPerM2 = "13.6";

            string minPlanetaryIRPerihelionWPerM2 = "13.7";
            string minPlanetaryIRAphelionWPerM2 = "13.4";
            string minPlanetaryIRMeanWPerM2 = "13.6";
        }


        public void saturnData()
        {
            string id = "699";
            string massX10_26Kg = "5.6834";
            string densityGCm3 = "0.687 ± 0.001";
            string equatorialRadius1BarKm = "60268 ± 4";
            string polarRadiusKm = "54364 ± 10";
            string volMeanRadiusKm = "58232 ± 6";
            string flattening = "0.09796";
            string geometricAlbedo = "0.47";
            string rockyCoreMassMcM = "0.1027";
            string siderealRotPeriodIII = "10h 39m 22.4s";
            string siderealRotRateRadPerS = "0.000163785";
            string meanSolarDayHrs = "~10.656";
            string gmKm3PerS2 = "37931206.234";
            string gm1SigmaKm3PerS2 = "± 98";
            string equatorialGravityGeMS2 = "10.44";
            string polarGravityGpMS2 = "12.14 ± 0.01";
            string visualMagnitudeV1_0 = "-8.88";
            string visualMagnitudeOpposition = "+0.67";
            string obliquityToOrbitDeg = "26.73";
            string siderealOrbitPeriodYears = "29.447498";
            string siderealOrbitPeriodDays = "10755.698";
            string meanDailyMotionDegPerDay = "0.0334979";
            string meanOrbitVelocityKmPerS = "9.68";
            string atmosphericTemperature1BarK = "134 ± 4";
            string escapeSpeedKmPerS = "35.5";
            string rocheLimitIceRp = "2.71";
            string hillsSphereRadiusRp = "1100";

            string solarConstantPerihelionWPerM2 = "16.8";
            string solarConstantAphelionWPerM2 = "13.6";
            string solarConstantMeanWPerM2 = "15.1";

            string maxPlanetaryIRPerihelionWPerM2 = "4.7";
            string maxPlanetaryIRAphelionWPerM2 = "4.5";
            string maxPlanetaryIRMeanWPerM2 = "4.6";

            string minPlanetaryIRPerihelionWPerM2 = "4.7";
            string minPlanetaryIRAphelionWPerM2 = "4.5";
            string minPlanetaryIRMeanWPerM2 = "4.6";
        }

        public void uranusData()
        {
            string id = "799";
            string massX10_24Kg = "86.813";
            string densityGCm3 = "1.271";
            string equatorialRadius1BarKm = "25559 ± 4";
            string polarRadiusKm = "24973 ± 20";
            string volMeanRadiusKm = "25362 ± 12";
            string flattening = "0.02293";
            string geometricAlbedo = "0.51";
            string siderealRotPeriodIIIHours = "17.24 ± 0.01";
            string siderealRotRateRadPerS = "-0.000101237";
            string meanSolarDayHours = "~17.24";
            string rockyCoreMassMcM = "0.0012";
            string gmKm3PerS2 = "5793951.256";
            string gm1SigmaKm3PerS2 = "± 4.3";
            string equatorialGravityGeMS2 = "8.87";
            string polarGravityGpMS2 = "9.19 ± 0.02";
            string visualMagnitudeV1_0 = "-7.11";
            string visualMagnitudeOpposition = "+5.52";
            string obliquityToOrbitDeg = "97.77";
            string siderealOrbitPeriodYears = "84.0120465";
            string siderealOrbitPeriodDays = "30685.4";
            string meanDailyMotionDegPerDay = "0.01176904";
            string meanOrbitVelocityKmPerS = "6.8";
            string atmosphericTemperature1BarK = "76 ± 2";
            string escapeSpeedKmPerS = "21.3";
            string rocheLimitIceRp = "2.20";
            string hillsSphereRadiusRp = "2700";

            string solarConstantPerihelionWPerM2 = "4.09";
            string solarConstantAphelionWPerM2 = "3.39";
            string solarConstantMeanWPerM2 = "3.71";

            string maxPlanetaryIRPerihelionWPerM2 = "0.72";
            string maxPlanetaryIRAphelionWPerM2 = "0.55";
            string maxPlanetaryIRMeanWPerM2 = "0.63";

            string minPlanetaryIRPerihelionWPerM2 = "0.72";
            string minPlanetaryIRAphelionWPerM2 = "0.55";
            string minPlanetaryIRMeanWPerM2 = "0.63";

        }

        public void neptuneData()
        {
            string id = "899";
            string massX10_24Kg = "102.409";
            string densityGCm3 = "1.638";
            string equatorialRadius1BarKm = "24766 ± 15";
            string volumeX10_10Km3 = "6254";
            string volMeanRadiusKm = "24624 ± 21";
            string polarRadiusKm = "24342 ± 30";
            string geometricAlbedo = "0.41";
            string flattening = "0.0171";
            string siderealRotPeriodIIIHours = "16.11 ± 0.01";
            string siderealRotRateRadPerS = "0.000108338";
            string meanSolarDayHours = "~16.11";
            string gmKm3PerS2 = "6835099.97";
            string gm1SigmaKm3PerS2 = "± 10";
            string equatorialGravityGeMS2 = "11.15";
            string polarGravityGpMS2 = "11.41 ± 0.03";
            string visualMagnitudeV1_0 = "-6.87";
            string visualMagnitudeOpposition = "+7.84";
            string obliquityToOrbitDeg = "28.32";
            string siderealOrbitPeriodYears = "164.788501027";
            string siderealOrbitPeriodDays = "60189";
            string meanDailyMotionDegPerDay = "0.006020076";
            string meanOrbitVelocityKmPerS = "5.43";
            string atmosphericTemperature1BarK = "72 ± 2";
            string escapeSpeed1BarKmPerS = "23.5";
            string rocheLimitIceRp = "2.98";
            string hillsSphereRadiusRp = "4700";

            string solarConstantPerihelionWPerM2 = "1.54";
            string solarConstantAphelionWPerM2 = "1.49";
            string solarConstantMeanWPerM2 = "1.51";

            string maxPlanetaryIRPerihelionWPerM2 = "0.52";
            string maxPlanetaryIRAphelionWPerM2 = "0.52";
            string maxPlanetaryIRMeanWPerM2 = "0.52";

            string minPlanetaryIRPerihelionWPerM2 = "0.52";
            string minPlanetaryIRAphelionWPerM2 = "0.52";
            string minPlanetaryIRMeanWPerM2 = "0.52";

        }

        public void plutoData()
        {
            string id = "999";
            string massX10_22Kg = "1.307 ± 0.018";
            string volumeX10_10Km3 = "0.697";
            string gmPlanetKm3PerS2 = "869.326";
            string densityR1195KmGCm3 = "1.86";
            string gm1SigmaKm3PerS2 = "0.4";
            string surfaceGravityMS2 = "0.611";
            string volMeanRadiusKm = "1188.3 ± 1.6";
            string massRatioMcMp = "0.122";
            string siderealRotPeriodHours = "153.29335198";
            string siderealRotRateRadPerS = "0.0000113856";
            string meanSolarDayHours = "153.2820";
            string meanOrbitVelocityKmPerS = "4.67";
            string siderealOrbitPeriodYears = "249.58932";
            string escapeSpeedKmPerS = "1.21";

            string solarConstantPerihelionWPerM2 = "1.56";
            string solarConstantAphelionWPerM2 = "0.56";
            string solarConstantMeanWPerM2 = "0.88";

            string maxPlanetaryIRPerihelionWPerM2 = "0.8";
            string maxPlanetaryIRAphelionWPerM2 = "0.3";
            string maxPlanetaryIRMeanWPerM2 = "0.5";

            string minPlanetaryIRPerihelionWPerM2 = "0.8";
            string minPlanetaryIRAphelionWPerM2 = "0.3";
            string minPlanetaryIRMeanWPerM2 = "0.5";

        }

        public void moonIdentifiersForGetRequests() 
        {
            

        }

    }
}
