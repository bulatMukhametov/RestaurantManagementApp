using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Services.Interfaces
{
    public interface IMenuService
    {
        public Task<MenuPositionDto> GetMenuPositionByIdAsync(long id, CancellationToken token = default);
        public Task<MenuPositionDto[]> GetActualMenuPositionsAsync(CancellationToken token = default);
        public Task<bool> CreateMenuPositionAsync(MenuPositionDto dto, CancellationToken token = default);
        public Task<bool> DeleteMenuPositionAsync(long id, CancellationToken token = default);
        public Task<bool> UpdateMenuPositionAsync(MenuPositionDto dto, CancellationToken token = default);
    }
}
