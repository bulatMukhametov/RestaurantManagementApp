using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDto> GetOrderAsync(long id, CancellationToken token = default);
        public Task<bool> CreateOrderAsync(OrderDto orderDto, CancellationToken token = default);
        public Task<BillDto> PayAsync(long id, CancellationToken token = default);
    }
}
