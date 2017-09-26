using Common.Authentication;
using Infrastructure.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly TimeSpan _tokenValidity;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(TimeSpan tokenValidity, IUserRepository userRepo)
        {
            _tokenValidity = tokenValidity;
            _userRepository = userRepo;
        }

        private const string SECRET = "{EFB5A17E-0621-4C98-8B7B-B51796C9F230}";

        private struct Payload
        {
            [JsonProperty("username")]
            public string Username { get; set; }
            [JsonProperty("loginDate")]
            public DateTime LoginDate { get; set; }
        }

        public void VerifyAction(string signedToken, string controller, string action)
        {
            signedToken = signedToken.Replace("Bearer ", string.Empty);

            var rawPayload = JWTHelper.DecodeSignedToken(signedToken, SECRET);

            var payload = JsonConvert.DeserializeObject<Payload>(rawPayload);

            if (DateTime.UtcNow.Subtract(payload.LoginDate) > _tokenValidity)
                throw new InvalidTokenException("Expired Token");
        }

        public async Task<string> LoginUser(string username, string password)
        {
            var isvalid = await _userRepository.ValidateUser(username, password);

            if (!isvalid)
                return string.Empty;

            //create jwt token

            var payload = new Dictionary<string, object>()
            {
                { "username", username },
                { "loginDate", DateTime.UtcNow }
            };

            var token = JWTHelper.CreateSignedToken(payload, SECRET);


            return token;
        }

        public Enums.RegisterResult RegisterUser(string username, string password)
        {
            try
            {
                _userRepository.CreateUser(new Models.Entities.User()
                {
                    Username = username,
                    Password = password
                });

                return Enums.RegisterResult.Registered;
            }
            catch (ObjectAlreadyExistsException ex)
            {
                //TODO: Add exception logging.

                return Enums.RegisterResult.UserAlreadyExists;
            }
        }
    }
}
