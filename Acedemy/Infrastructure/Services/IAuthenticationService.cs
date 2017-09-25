using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        string LoginUser(string username, string password);
        void VerifyAction(string signedToken, string controller, string action);
        void RegisterUser(string username, string password);
    }
}
