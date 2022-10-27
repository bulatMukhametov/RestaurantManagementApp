using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data;
using RestaurantManagement.Dto;

namespace ReastaurantManagement.Services
{
    public class MenuReportService
    {
        private readonly RestaurantContext _dbContext;

        public MenuReportService(RestaurantContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MenuReportDto[]> GetReportAsync(DateTime date)
        {
            return await _dbContext.MenuPositions
                .Where(x=> x.StartDate <= date && x.EndDate <= date)
                .Select(x => new MenuReportDto
                {
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Price = x.Price,
                })
                .ToArrayAsync();
        }
    }
}
