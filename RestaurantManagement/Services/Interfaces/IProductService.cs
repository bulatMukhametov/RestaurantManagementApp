using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDto[]> GetAllProductsAsync(CancellationToken token = default);
        public Task<ProductDto> GetProductByIdAsync(long id, CancellationToken token = default);
        public Task<bool> СreateProductAsync(ProductDto productDto, CancellationToken token = default);
        public Task<bool> UpdateProductAsync(ProductDto productDto, CancellationToken token = default);
        public Task<bool> DeleteProductAsync(long id, CancellationToken token = default);
    }
}
