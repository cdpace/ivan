using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using IAuthService = Infrastructure.Services.IAuthenticationService;

namespace FrontEnd.Filters
{
    public class JWTValidationFilter : ActionFilterAttribute
    {
        private IAuthService AuthService { get; }

        public JWTValidationFilter()
        {
            AuthService = new AuthenticationService();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authHeader = ((FrameRequestHeaders)context?.HttpContext?.Request?.Headers)?.HeaderAuthorization;
            
            if (authHeader.HasValue && !string.IsNullOrWhiteSpace(authHeader.Value))
            {
                var token = AuthService.VerifyAction(authHeader.Value, string.Empty, string.Empty);
            }
            else
            {
                
            }



        }
    }
}
