using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Models.ApiRequests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authService;

        public UserController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Produces(typeof(string))]
        public Task<string> Post([FromBody]UserRegisterRequest request)
        {
            var registerResult = _authService.RegisterUser(request.Username, request.Password);

            switch (registerResult)
            {
                case Infrastructure.Enums.RegisterResult.Registered:
                    return Task.FromResult("Done");
                case Infrastructure.Enums.RegisterResult.UserAlreadyExists:
                    return Task.FromResult("UserAlreadyExists");
                default:
                    return Task.FromResult("Error");
            }
        }

        [HttpGet]
        public async Task<string> Get([FromQuery]UserLoginRequest request)
        {
            var result = await _authService.LoginUser(request.Username, request.Password);

            if (string.IsNullOrWhiteSpace(result))
                return "Invalid Login";

            return result;
        }

    }
}
