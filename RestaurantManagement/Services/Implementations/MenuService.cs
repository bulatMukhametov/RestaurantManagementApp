using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data;
using ReastaurantManagement.Data.Domain;
using ReastaurantManagement.Dto;
using ReastaurantManagement.Services.Interfaces;

namespace ReastaurantManagement.Services
{
    public class MenuService: IMenuService
    {
        private readonly RestaurantContext _context;

        public MenuService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<MenuPositionDto> GetMenuPositionByIdAsync(long id, CancellationToken token = default)
        {
            var menuPosition = await _context.MenuPositions
                .FirstOrDefaultAsync(x => x.Id == id, token);

            if (menuPosition == null)
            {
                throw new Exception("Menu position not found");
            }

            return new MenuPositionDto
            {
                Id = menuPosition.Id,
                StartDate = menuPosition.StartDate,
                EndDate = menuPosition.EndDate,
                Name = menuPosition.Name,
                IsActive = menuPosition.IsActive,
                Price = menuPosition.Price
            };
        }

        public async Task<MenuPositionDto[]> GetActualMenuPositionsAsync(CancellationToken token = default)
        {
            return await _context.MenuPositions
                .Where(x=> x.IsActive)
                .Select(x => new MenuPositionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsActive = x.IsActive,
                })
                .ToArrayAsync(token);
        }

        public async Task<bool> CreateMenuPositionAsync(MenuPositionDto dto, CancellationToken token = default)
        {
            //TODO Validate having enought products

            //TODO Use Automapping (maybe Automapper)           
            var menuPosition = new MenuPosition
            {
                Id = dto.Id,
                IsActive = dto.IsActive,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate,
                Name = dto.Name,
                Price = dto.Price
            };

            await _context.AddAsync(menuPosition, token);
            await _context.SaveChangesAsync(token);

            return true;
        }

        public async Task<bool> UpdateMenuPositionAsync(MenuPositionDto dto, CancellationToken token = default)
        {
            var menuPosition = await _context.MenuPositions.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (menuPosition == null)
            {
                throw new Exception("Menu position not found");
            }

            //TODO Use Automapping (maybe Automapper)     
            menuPosition.Name = dto.Name;
            menuPosition.IsActive = dto.IsActive;
            menuPosition.EndDate = dto.EndDate;
            menuPosition.StartDate = dto.StartDate;
            menuPosition.Price = dto.Price;

            await _context.SaveChangesAsync(token);

            return true;
        }

        public async Task<bool> DeleteMenuPositionAsync(long id, CancellationToken token = default)
        {
            var menuPosition = await _context.FindAsync<MenuPosition>(id);

            if (menuPosition == null)
            {
                throw new Exception("Menu position not found");
            }

            _context.MenuPositions.Remove(menuPosition);
            await _context.SaveChangesAsync(token);

            return true;
        }
    }
}
