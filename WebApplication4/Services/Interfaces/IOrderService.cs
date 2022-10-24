using WebApplication4.Dto;

namespace WebApplication4.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> CreateOrderAsync(OrderDto orderDto, CancellationToken token = default);
        public Task<BillDto> GetBillAsync(long orderId, CancellationToken token = default);
    }
}
