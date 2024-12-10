﻿using OurSolarSystemAPI.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OurSolarSystemAPI.Repository.MySQL;
using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testsController(OurSolarSystemContext context) : ControllerBase
    {
        private readonly OurSolarSystemContext _context = context;

        // GET: api/planets
        [HttpGet]
        public ActionResult<IEnumerable<Planet>> GetPlanets()
        {
            return _context.Planets.ToList();
        }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "password")
        {
            var token = JwtTokenGenerator.GenerateJwtToken(username, "admin");
            return Ok(new { token });
        }
        return Unauthorized();
    }

    [HttpGet("authorization-test")]
    [Authorize(Policy = "AdminOnly")]
    public IActionResult AuthorizationTest()
    {
        
        return Ok(new { StatusCode = 200 });
    }
    }
}
