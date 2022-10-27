using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data;
using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Services
{
    public class ProductReportService
    {
        private readonly RestaurantContext _dbContext;

        public ProductReportService(RestaurantContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductReportDto[]> GetReportAsync()
        {
            return await _dbContext.Products
                .Select(p => new ProductReportDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Count = p.Count,
                })
                .ToArrayAsync();
        }
    }
}
