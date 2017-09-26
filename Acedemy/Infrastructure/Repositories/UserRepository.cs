using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using MySql;
using MySql.Data.MySqlClient;
using Dapper;
using PasswordHash;
using Infrastructure.Exceptions;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        protected string ConnectionString
        {
            get
            {
                return _config.GetConnectionString("databaseConnectionString");
            }
        }

        public async Task CreateUser(User user)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                var checkQuery = "SELECT 1 FROM users WHERE Username = @Username and Password = @Password";

                var query = "INSERT INTO `acedemy`.`Users`(`Username`,`Password`,`Firstname`,`Lastname`)" +
                    "VALUES (@Username,@Password,@Firstname,@Lastname);";

                var command = new MySqlCommand(checkQuery, connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", Encrypt.SHA512(user.Password));

                var res = await command.ExecuteScalarAsync();

                if (res != null)
                    throw new ObjectAlreadyExistsException("User with the same details already exits");

                command.CommandText = query;

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT 1 FROM users where Username = @Username and Password = @Password";

                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", Encrypt.SHA512(password));

                var result = await command.ExecuteScalarAsync();

                if (result == null || ((int)result) <= 0)
                    return false;

                return true;

            }
        }
    }
}
