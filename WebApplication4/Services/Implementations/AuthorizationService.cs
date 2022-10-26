using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ReastaurantManagement.Data;
using ReastaurantManagement.Services.Interfaces;

namespace ReastaurantManagement.Services.Implementations
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

        public async Task<bool> LoginAsync(string login, string password, CancellationToken token = default)
        {
            //TODO Validation, Logging                  
            var user = await _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Login == login && x.Password == password, token);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await _httpContext.HttpContext.SignInAsync(claimsPrincipal);

            return true;
        }

        public async Task<bool> LogoutAsync(CancellationToken token = default)
        {
            //TODO Validation, Logging    
            await _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return true;
        }
    }
}
