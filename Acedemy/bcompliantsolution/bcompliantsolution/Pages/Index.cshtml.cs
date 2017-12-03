using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Authentication;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.User;

namespace bcompliantsolution.Pages
{
    public class IndexModel : PageModel
    {
        public async Task OnGet()
        {
            var connectionString = "Server=127.0.0.1:8889;Database=bcompliantsolutions;Uid=root;Pwd=root;";
            var sessionService = new SessionService();

            var userRepo = new MySqlDapperRepository<User>("users", connectionString, sessionService);

            await userRepo.Add(new User()
            {
                Username = "cdpace",
                Password = "test".GetHashCode().ToString()
            });
        }
    }
}
