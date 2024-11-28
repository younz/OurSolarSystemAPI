using OurSolarSystemAPI.Models;

namespace OurSolarSystemAPI.Repository
{
    public class Usercreation
    {

        public void Create(User user)
        { // this part checks if the user is an admin and if so, it creates an admin object instead of a user object to add to the database
            if (user.Roles is roles.Admin)
            {
                user = new Admin
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Roles = roles.Admin
                };
            }
           

        }

        public bool VerifyPassword(string inputPassword, User user)
        {
            string hashedInputPassword = User.HashPassword(inputPassword);
            if (user.Password == hashedInputPassword)
            {
                return true;
            }

            throw new Exception("Password is incorrect");
        }
    }
}
