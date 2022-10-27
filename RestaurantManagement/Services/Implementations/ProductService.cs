using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data;
using ReastaurantManagement.Data.Domain;
using ReastaurantManagement.Dto;
using ReastaurantManagement.Services.Interfaces;

namespace ReastaurantManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly RestaurantContext _dbContext;

        public ProductService(RestaurantContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDto[]> GetAllProductsAsync(CancellationToken token = default)
        {
            return await _dbContext.Products
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Count,
                    Price = x.Price,
                })
                .ToArrayAsync(token);
        }

        public async Task<ProductDto> GetProductByIdAsync(long id, CancellationToken token = default)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(x => x.Id == id, token);

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

        public async Task<bool> СreateProductAsync(ProductDto productDto, CancellationToken token = default)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Count = productDto.Count,
            };

            await _dbContext.Products.AddAsync(product, token);
            await _dbContext.SaveChangesAsync(token);

            return true;
        }

        public async Task<bool> UpdateProductAsync(ProductDto productDto, CancellationToken token = default)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(x => x.Id == productDto.Id);
            
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Price = productDto.Price;
            product.Count = productDto.Count;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(long id, CancellationToken token = default)
        {
            var product = await _dbContext.FindAsync<Product>(id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync(token);

            return true;
        }
    }
}
