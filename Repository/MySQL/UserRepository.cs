using OurSolarSystemAPI.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Repository.MySQL;
using OurSolarSystemAPI.Utility;

namespace OurSolarSystemAPI.Repository
{
    public class UserDto 
    {
        public required string username { get; set; }
        public required string role { get; set; }
        public required int id { get; set; }
    }
    public class UserRepositoryMySQL
    {

        private readonly OurSolarSystemContext _context;

        public UserRepositoryMySQL(OurSolarSystemContext context) 
        {
            _context = context;
        }

        public async Task<List<UserDto>> RequestAllUsers()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    username = u.Username,
                    role = u.Role,
                    id = u.Id
                })
                .ToListAsync();
        }

        public async Task<UserDto> RequestUserById(int id) 
        {
            return await _context.Users.Where(u => u.Id == id)
            .Select(u => new UserDto
                {
                    username = u.Username,
                    role = u.Role,
                    id = u.Id
                })
            .FirstOrDefaultAsync() ?? throw new Exception();

        }

        public async Task<UserDto> RequestUserByUsername(string username) 
        {
            return await _context.Users.Where(u => u.Username == username)
            .Select(u => new UserDto
                {
                    username = u.Username,
                    role = u.Role,
                    id = u.Id
                })
            .FirstOrDefaultAsync() ?? throw new Exception();

        }

        public async Task<UserDto> RequestUserByUsernameAndPassword(string username, string password) 
        {
            return await _context.Users.Where(u => u.Username == username && u.Password == password)
            .Select(u => new UserDto
                {
                    username = u.Username,
                    role = u.Role,
                    id = u.Id
                })
            .FirstOrDefaultAsync() ?? throw new Exception();

        }

        public async Task CreateUser(UserEntity user) 
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(string username, string oldPassword, string newPassword, string newSalt) 
        {
             string oldPasswordHashed = UserEntity.HashPassword(oldPassword);
            UserEntity user = await _context.Users
            .Where(u => u.Username == username)
            .FirstAsync() ?? throw new Exception("User not found");

            byte[] salt = Convert.FromBase64String(user.PasswordSalt);
            string hashedOldPassword = UserEntity.HashPasswordWithSalt(oldPassword, salt);

            if (hashedOldPassword != user.Password) throw new Exception("incorrect password");

            user.Password = newPassword;
            user.PasswordSalt = newSalt;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true; 
        }

        public static bool VerifyUsername(string inputUsername, UserEntity user)
        { 
            if (user.Username == inputUsername)
            {
                return true;
            }
            throw new UnauthorizedAccessException("Username is incorrect");
        }

        public static bool VerifyPassword(string inputPassword, UserEntity user)
        {
            string hashedInputPassword = UserEntity.HashPassword(inputPassword);
            if (user.Password == hashedInputPassword)
            {
                return true;
            }

            throw new UnauthorizedAccessException("Password is incorrect");
        }
    }
}
