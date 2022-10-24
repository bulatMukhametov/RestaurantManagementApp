using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dto;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<BillDto> GetBill(long orderId)
        {
            return await _orderService.GetBillAsync(orderId);
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] OrderDto orderDto)
        {
            return await _orderService.CreateOrderAsync(orderDto);
        }
    }
}
