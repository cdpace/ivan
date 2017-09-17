using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using IAuthService = Infrastructure.Services.IAuthenticationService;
using FrontEnd.Filters;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService AuthService;

        public HomeController(IAuthService authService)
        {
            AuthService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [JWTValidationFilter]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            return Content(AuthService.LoginUser(username, password));
        }
    }
}
