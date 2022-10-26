using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data;
using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Services
{
    public class ProductReportService
    {
        private readonly RestaurantContext _context;

        public ProductReportService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<ProductDto[]> GetReportAsync()
        {
            return await _context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Count = p.Count,
            }).ToArrayAsync();
        }

    }
}
