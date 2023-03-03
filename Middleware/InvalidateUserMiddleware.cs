using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Hotel.Middleware
{
    public class InvalidatedUserMiddleware
    {
        private readonly RequestDelegate _next;

        public InvalidatedUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ClaimsPrincipal user = context.User;
            if (user.Identity.IsAuthenticated)
            {
                string username = user.FindFirstValue(ClaimTypes.NameIdentifier);
                if (InvalidatedUsersList.IsUserInvalidated(username))
                {
                    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    context.Response.Redirect("/Account/Login");
                    return;
                }
            }

            await _next(context);
        }
    }

}
