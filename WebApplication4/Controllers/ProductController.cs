using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReastaurantManagement.Dto;
using ReastaurantManagement.Services.Interfaces;

namespace ReastaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _productService.GetAsync(id);
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] ProductDto product)
        {
            return await _productService.СreateProductAsync(product);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //TODO
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            //TODO
        }
    }
}
