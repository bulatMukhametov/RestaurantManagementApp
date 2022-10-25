using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dto;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
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


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return await _productService.GetAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _productService.GetAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<bool> Post([FromBody] ProductDto product)
        {
            return await _productService.СreateProductAsync(product);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
