using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication4.Data;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly RestaurantContext _dbContext;

        public AuthorizationService(IHttpContextAccessor httpContext, RestaurantContext dbContext)
        {
            _httpContext = httpContext;
            _dbContext = dbContext;
        }

        public async Task Login(string login, string password)
        {
            var user = await _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Login == login && x.Password == password);

            if (user == null)
            {

            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await _httpContext.HttpContext.SignInAsync(claimsPrincipal);
        }

        public async Task Logout()
        {
            await _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
