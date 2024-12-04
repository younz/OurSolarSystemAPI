using OurSolarSystemAPI.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OurSolarSystemAPI.Utility;

namespace OurSolarSystemAPI.Repository
{
    public class UserRepository(IConfiguration configuration) :  ConnectionHelper(configuration: configuration)
    {


        // this class is used to create users and admins and add them to the database

        public async Task<List<User>> GetallUsersAsync()
        {
            List<User> users = new List<User>();
             // Replace with your actual connection string

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Users"; // Adjust the query as needed

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = new User // Assuming ConcreteUser is a concrete implementation of User
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

        public async Task<User?> GetUserAsync(int id)
        {
            List<User> users = await GetallUsersAsync();
            return users.Find(user => user.Id == id );
        }

        public async Task<bool> CreateUser(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            { 
                
                string query = "INSERT INTO Users (Id, Username, Password, Roles) VALUES (@Id, @Username, @Password, @Roles)";

                using (MySqlCommand command = new MySqlCommand())
                {
                    if (user.Roles is roles.Admin)
                    {
                        var admin = new Admin { Id = user.Id, Username = user.Username, Password = user.Password, Roles = roles.Admin };
                        command.Parameters.AddWithValue("@Id", admin.Id);
                        command.Parameters.AddWithValue("@Username", admin.Username);
                        command.Parameters.AddWithValue("@Password", admin.Password);
                        command.Parameters.AddWithValue("@Roles", admin.Roles.ToString());
                        await command.Connection.OpenAsync();
                        var noOfRow = command.ExecuteNonQuery();
                        if (noOfRow == 1)
                        {
                            return true;
                        }
                        return false;
                        // Add admin to the database and check if it was successful
                    }
                    else // Add user to the database
                    {
                        command.Parameters.AddWithValue("@Id", user.Id);
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Roles", user.Roles.ToString());
                        await command.Connection.OpenAsync();
                        var noOfRow await command.ExecuteNonQueryAsync();
                        if (noOfRow == 1)
                        {
                            return true;
                        }
                        return false;
                        
                    }
                }
                // this part checks if the user is an admin and if so, it creates an admin object instead of a user object to add to the database
                

            }
           
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await GetUserAsync(id);
            if (user.Roles is not roles.Admin) return false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Users WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    var noOfRow = await command.ExecuteNonQueryAsync();
                    if (noOfRow == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public static bool VerifyPassword(string inputPassword, User user)
        {
            string hashedInputPassword = user.HashPassword(inputPassword);
            if (user.Password == hashedInputPassword)
            {
                return true;
            }

            throw new UnauthorizedAccessException("Password is incorrect");
        }
    }
}
