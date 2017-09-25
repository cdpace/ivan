using System;
using System.Threading.Tasks;
using Models.Entities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<bool> ValidateUser(string username, string password)
    }
}
