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

        protected string ConnectionString {
            get{
                return _config.GetConnectionString("databaseConnectionString");
            }
        }

        public async Task CreateUser(User user)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

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
    }
}
