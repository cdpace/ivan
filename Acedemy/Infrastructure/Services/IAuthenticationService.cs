using System.Threading.Tasks;
using Infrastructure.Enums;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        Task<string> LoginUser(string username, string password);
        void VerifyAction(string signedToken, string controller, string action);
        RegisterResult RegisterUser(string username, string password);
    }
}
