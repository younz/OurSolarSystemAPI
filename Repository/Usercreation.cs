using OurSolarSystemAPI.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace OurSolarSystemAPI.Repository
{
    public class Usercreation
    {
        // this class is used to create users and admins and add them to the database

        public async Task<List<User>> GetallUsersAsync()
        {
            List<User> users = new List<User>();
            string connectionString = "your_connection_string_here"; // Replace with your actual connection string

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT Id, Username, Password, Roles FROM Users"; // Adjust the query as needed

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Roles = (roles)Enum.Parse(typeof(roles), reader.GetString(3))
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public User GetUser(int id)
        {
            List<User> users = GetallUsersAsync().Result;
            return users.Find(user => user.Id == id);
        }

        public void CreateUser(User user)
        {
            // this part checks if the user is an admin and if so, it creates an admin object instead of a user object to add to the database
            if (user.Roles is roles.Admin)
            {
                user = new Admin { Id = user.Id, Username = user.Username, Password = user.Password, Roles = roles.Admin };
            }
        }

        public static bool VerifyPassword(string inputPassword, User user)
        {
            string hashedInputPassword = user.HashPassword(inputPassword);
            if (user.Password == hashedInputPassword)
            {
                return true;
            }

            throw new Exception("Password is incorrect");
        }
    }
