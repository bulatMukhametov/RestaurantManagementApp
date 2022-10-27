using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReastaurantManagement.Dto;
using ReastaurantManagement.Services.Interfaces;

namespace ReastaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Get order by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Bill</returns>
        [HttpGet("{id}")]
        public async Task<OrderDto> Get(long id)
        {
            return await _orderService.GetOrderAsync(id);
        }

        /// <summary>
        /// Pay for order and get bill
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Bill</returns>
        [HttpGet("Pay")]
        public async Task<BillDto> Pay(long orderId)
        {
            return await _orderService.PayForOrderAsync(orderId);
        }

        /// <summary>
        /// Create new order
        /// </summary>
        /// <param name="orderDto">Order model</param>
        /// <returns>Operation status</returns>
        [HttpPost]
        public async Task<bool> Post([FromBody] OrderDto orderDto)
        {
            return await _orderService.CreateOrderAsync(orderDto);
        }
    }
}
