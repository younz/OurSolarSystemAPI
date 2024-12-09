using Microsoft.AspNetCore.Mvc;
using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository;
using System.Threading.Tasks;
using System;

namespace OurSolarSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly UserRepository _context;

    public UserController(UserRepository context)
    {
        _context = context;
    }

    [HttpGet] // GET /api/users
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _context.GetallUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpGet] // GET /api/user/
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _context.GetUserAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpDelete("{id}")] // DELETE /api/user/{id}
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            var user = await _context.GetUserAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var result = await _context.DeleteUser(id);
            if (!result)
            {
                return StatusCode(500, "Failed to delete the user.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpPost] // POST /api/user
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        try
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            var result = await _context.CreateUser(user);
            if (!result)
            {
                return StatusCode(500, "Failed to create the user.");
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpPut("{id}")] // PUT /api/user/{id}
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    {
        try
        {
            if (user == null || user.Id != id)
            {
                return BadRequest("User is null or ID mismatch.");
            }

            var existingUser = await _context.GetUserAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            var result = await _context.UpdateUser(user);
            if (!result)
            {
                return StatusCode(500, "Failed to update the user.");
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
}
