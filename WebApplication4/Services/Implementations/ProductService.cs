using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Data.Domain;
using WebApplication4.Dto;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services
{
    public class ProductService : IProductService
    {
        private readonly RestaurantContext _context;

        public ProductService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<ProductDto[]> GetAllAsync()
        {
            return await _context.Products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Count,
                    Price = x.Price,
                })
                .ToArrayAsync();
        }

        public async Task<ProductDto> GetAsync(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            return new ProductDto
            {
                Id = id,
                Name = product.Name,
                Count = product.Count,
                Price = product.Price,
            };
        }

        public async Task<bool> СreateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Count = productDto.Count,
            };

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateProductAsync(ProductDto productDto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == productDto.Id);
            
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Price = productDto.Price;
            product.Count = productDto.Count;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
