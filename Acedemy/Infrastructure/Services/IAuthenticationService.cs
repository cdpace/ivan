using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IAuthenticationService
    {
        string LoginUser(string username, string password);
        bool VerifyAction(string signedToken, string controller, string action);
    }
}
