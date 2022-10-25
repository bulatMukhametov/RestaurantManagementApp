using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dto;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthorizationService _autorizationService;

        public LoginController(IAuthorizationService autorizationService)
        {
            _autorizationService = autorizationService;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async void Post([FromBody] LoginDto dto)
        {
            await _autorizationService.Login(dto.Login, dto.Password);
        }
    }
}
