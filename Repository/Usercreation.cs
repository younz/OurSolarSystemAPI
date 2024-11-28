using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository
{
    public class Usercreation
    {

        public void Create(User user)
        {
            // Add user to database

        }

        public bool VerifyPassword(string inputPassword, User user)
        {
            string hashedInputPassword = User.HashPassword(inputPassword);
            if (user.Password == hashedInputPassword)
            {
                return true;
            }
            else
            {
                throw new Exception("Password is incorrect");
            }
        }
    }
}
