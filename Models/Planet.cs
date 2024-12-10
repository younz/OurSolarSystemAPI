﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OurSolarSystemAPI.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public int HorizonId { get; set; }
        public List<Moon>? Moons { get; set; }
        public List<EphemerisPlanet>? Ephemeris { get; set; }
        public string Name { get; set; }
        public string? VolumeMeanRadius { get; set; }
        public string? Density { get; set; }
        public string? Mass { get; set; }
        public string? Volume { get; set; }
        public string? EquatorialRadius { get; set; }
        public string? SiderealRotationPeriod { get; set; }
        public string? SiderealRotationRate { get; set; }
        public string? MeanSolarDay { get; set; }
        public string? PolarGravity { get; set; }
        public string? EquatorialGravity { get; set; }
        public string? GeometricAlbedo { get; set; }
        public string? MassRatioToSun { get; set; }
        public string? MeanTemperature { get; set; }
        public string? AtmosphericPressure { get; set; }
        public string? ObliquityToOrbit { get; set; }
        public string? MaxAngularDiameter { get; set; }
        public string? MeanSideRealOrbitalPeriod { get; set; }
        public string? OrbitalSpeed { get; set; }
        public string? HillsSphereRadius { get; set; }
        public string? EscapeSpeed { get; set; }
        public string? GravitationalParameter { get; set; }
        public string? SolarConstantPerihelion { get; set; }
        public string? SolarConstantAphelion { get; set; }
        public string? SolarConstantMean { get; set; }
        public string? MaxPlanetaryIRPerihelion { get; set; }
        public string? MaxPlanetaryIRAphelion { get; set; }
        public string? MaxPlanetaryIRMean { get; set; }
        public string? MinPlanetaryIRPerihelion { get; set; }
        public string? MinPlanetaryIRAphelion { get; set; }
        public string? MinPlanetaryIRMean { get; set; }

        
    }

    

}
