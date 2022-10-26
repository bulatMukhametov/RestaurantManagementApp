using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReastaurantManagement.Data.Domain;
using ReastaurantManagement.Dto;
using ReastaurantManagement.Services.Interfaces;


namespace ReastaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// Get actual menu positions
        /// </summary>
        /// <returns>MenuPositionDto[]</returns>
        [HttpGet]
        public async Task<MenuPositionDto[]> Get()
        {
            return await _menuService.GetActualMenuPositionsAsync();
        }

        /// <summary>
        /// Get menu position by Id
        /// </summary>
        /// <returns>MenuPositionDto</returns>
        [HttpGet("{id}")]
        public async Task<MenuPositionDto> Get(int id)
        {
            return await _menuService.GetMenuPositionByIdAsync(id);
        }

        /// <summary>
        /// Create new menu position
        /// </summary>
        [HttpPost]
        public async Task<bool> Post([FromBody] MenuPositionDto dto)
        {
            return await _menuService.CreateMenuPositionAsync(dto);
        }

        /// <summary>
        /// Update menu position
        /// </summary>
        [HttpPut]
        public async Task<bool> Put([FromBody] MenuPositionDto dto)
        {
            return await _menuService.UpdateMenuPositionAsync(dto);
        }

        /// <summary>
        /// Delete menu position
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _menuService.DeleteMenuPositionAsync(id);
        }
    }
}
