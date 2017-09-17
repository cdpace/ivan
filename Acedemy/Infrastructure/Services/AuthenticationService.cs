using Common.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string SECRET = "{EFB5A17E-0621-4C98-8B7B-B51796C9F230}";

        public bool VerifyAction(string signedToken, string controller, string action)
        {
            try
            {
                signedToken = signedToken.Replace("Bearer ", string.Empty);

                var token = JWTHelper.DecodeSignedToken(signedToken, signedToken);

                //TODO: Add more verification


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string LoginUser(string username, string password)
        {
            //TODO: Verify Username/ Password against database

            //create jwt token

            var payload = new Dictionary<string, object>()
            {
                { "username", username },
                { "loginDate", DateTime.UtcNow }
            };

            var token = JWTHelper.CreateSignedToken(payload, SECRET);


            return token;
        }
    }
}
