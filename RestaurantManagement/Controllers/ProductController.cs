using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReastaurantManagement.Dto;
using ReastaurantManagement.Services.Interfaces;
using RestaurantManagement.Constants;

namespace ReastaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = ProjectConstants.AdminRoleName)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>IEnumerable<ProductDto></returns>
        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await _productService.GetAllProductsAsync();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <returns>ProductDto</returns>
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <returns>MenuPositionDto[]</returns>
        [HttpPost]
        public async Task<bool> Post([FromBody] ProductDto product)
        {
            return await _productService.СreateProductAsync(product);
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <returns>MenuPositionDto[]</returns>
        [HttpPut]
        public async Task<bool> Put([FromBody] ProductDto product)
        {
            return await _productService.UpdateProductAsync(product);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <returns>MenuPositionDto[]</returns>
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            return await _productService.DeleteProductAsync(id);
        }
    }
}
