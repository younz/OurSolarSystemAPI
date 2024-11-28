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
    public abstract class User
    {
        private string _password;
        public required int Id { get; set; } 
        public required string Username { get; set; }
        public required string Password
        {
            get => _password;
            set => _password = HashPassword(value);
        }

        public string HashPassword(string password)
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

        public abstract roles Roles 
        {
            get;
            set;
        } 

    }
}
