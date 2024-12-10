using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Repository;
using System.Security.Cryptography;
using System.Text;

namespace OurSolarSystemAPI.Models
{
    public enum roles
    {
        Admin,
        User,
        Guest,
        manintainer,
        developer
    }
    public class UserEntity
    {
        private string _password;
        public int Id { get; set; } 
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string PasswordSalt { get; set; }
        public required string Role { get; set; }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string HashPasswordWithSalt(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];
            Array.Copy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Array.Copy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(saltedPassword);

                byte[] hashWithSalt = new byte[hashBytes.Length + salt.Length];
                Array.Copy(hashBytes, 0, hashWithSalt, 0, hashBytes.Length);
                Array.Copy(salt, 0, hashWithSalt, hashBytes.Length, salt.Length);

                return Convert.ToBase64String(hashWithSalt);
            }
        }


        public static (byte[] bytes, string salt) GenerateSalt(int length = 16)
        {
            byte[] saltBytes = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes); 
            }
            return (saltBytes, Convert.ToBase64String(saltBytes));
        }


    }
}
