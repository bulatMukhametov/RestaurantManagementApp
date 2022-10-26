using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDto[]> GetAllAsync();
        public Task<ProductDto> GetAsync(long id);
        public Task<bool> СreateProductAsync(ProductDto productDto);
    }
}
