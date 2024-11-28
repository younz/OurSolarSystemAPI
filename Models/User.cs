using System.Security.Cryptography;
using System.Text;

namespace OurSolarSystemAPI.Models
{
    public abstract class User
    {
        private string _password;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password
        {
            get => _password;
            set => _password = HashPassword(value);
        }


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
        public abstract void Role();
    }
}
