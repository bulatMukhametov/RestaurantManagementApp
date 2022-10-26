using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Services.Interfaces.IAuthorizationService _autorizationService;

        public LoginController(Services.Interfaces.IAuthorizationService autorizationService)
        {
            _autorizationService = autorizationService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginDto">Login model</param>
        /// <returns>Operation status</returns>
        [HttpPost]
        public async Task<bool> Post([FromBody] LoginDto loginDto)
        {
            //TODO Logging
            return await _autorizationService.LoginAsync(loginDto.Login, loginDto.Password);         
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns>Operation status</returns>
        [HttpPost("Logout")]
        [Authorize]
        public async Task<bool> Logout()
        {
            //TODO Logging
            return await _autorizationService.LogoutAsync();         
        }
    }
}
