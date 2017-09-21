using Infrastructure.Exceptions;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System;
using IAuthService = Infrastructure.Services.IAuthenticationService;

namespace FrontEnd.Filters
{
    public class JWTValidationFilter : ActionFilterAttribute
    {
        private IAuthService AuthService { get; }

        public JWTValidationFilter()
        {
            AuthService = new AuthenticationService(TimeSpan.FromMinutes(1));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authHeader = ((FrameRequestHeaders)context?.HttpContext?.Request?.Headers)?.HeaderAuthorization;
            
            if (authHeader.HasValue && !string.IsNullOrWhiteSpace(authHeader.Value))
            {
                try
                {
                    AuthService.VerifyAction(authHeader.Value, string.Empty, string.Empty);
                }
                catch (InvalidTokenException)
                {
                    context.Result = new StatusCodeResult(401);
                }
            }
            
        }
    }
}
