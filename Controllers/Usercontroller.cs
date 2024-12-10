using Microsoft.AspNetCore.Mvc;
using OurSolarSystemAPI.Models;
using OurSolarSystemAPI.Repository;
using System.ComponentModel.DataAnnotations;

namespace OurSolarSystemAPI.Controllers;

public class userDTONewUser 
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required string RepeatPassword { get; set; }
}

public class userDTOUpdatePassword 
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
    [Required]
    public required string NewPassword { get; set; }
    [Required]
    public required string RepeatNewPassword { get; set; }
}

[ApiController]
[Route("api/users")]
public class UserController : Controller
{
    private readonly UserRepositoryMySQL _userRepo;

    public UserController(UserRepositoryMySQL userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpGet("get-all-users")]
    public async Task<IActionResult> RequestAllUsers()
    {
        List<UserDto> users = await _userRepo.RequestAllUsers();

        return Ok(users);
 
    }
    [HttpGet("get-user-by-id")]
    public async Task<IActionResult> RequestUserById(int id)
    {
        UserDto user = await _userRepo.RequestUserById(id);

        return Ok(user);
    }



    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] userDTONewUser requestBody)
    {
        (byte[] saltBytes, string salt) = UserEntity.GenerateSalt();
        string hashedPassword = UserEntity.HashPasswordWithSalt(requestBody.Password, saltBytes);
        string hashedRepeatPassword = UserEntity.HashPasswordWithSalt(requestBody.RepeatPassword, saltBytes);

        if (hashedPassword != hashedRepeatPassword) throw new Exception("Passwords doesn't match");

        var user = new UserEntity
        {
            Username = requestBody.Username,
            Password = hashedPassword,
            PasswordSalt = salt,
            Role = "user"
        };
    
        await _userRepo.CreateUser(user);

        return Ok();
    }



    [HttpPut("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] userDTOUpdatePassword requestBody)
    {
        (byte[] saltBytes, string salt) = UserEntity.GenerateSalt();
        string hashedNewPassword = UserEntity.HashPasswordWithSalt(requestBody.NewPassword, saltBytes);
        string hashedRepeatNewPassword = UserEntity.HashPasswordWithSalt(requestBody.RepeatNewPassword, saltBytes);

        if (hashedNewPassword != hashedRepeatNewPassword) throw new Exception("Passwords doesn't match");

        bool response = await _userRepo.UpdateUser(requestBody.Username, requestBody.Password, hashedNewPassword, salt);

        if (response) return Ok();
        else return BadRequest();
    }
}
