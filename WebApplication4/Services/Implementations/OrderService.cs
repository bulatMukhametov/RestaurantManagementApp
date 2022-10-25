using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Data.Domain;
using WebApplication4.Dto;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantContext _context;

        public OrderService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOrderAsync(OrderDto orderDto, CancellationToken token = default)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(token);
            
            try
            {
                var newOrder = new Order
                {
                    CreateDate = orderDto.CreateDate,
                    CustomerId = orderDto.CustomerId,
                    EmployeeId = orderDto.EmployeeId,
                };

                await _context.AddAsync(newOrder, token);
                await _context.SaveChangesAsync(token);

                foreach (var menuPositionId in orderDto.MenuPositionIds)
                {
                    var newOrderPosition = new OrderPosition
                    {
                        MenuPositionId = menuPositionId,
                        OrderId = newOrder.Id
                    };
                    await _context.AddAsync(newOrderPosition, token);
                }

                await _context.SaveChangesAsync(token);
                await transaction.CommitAsync(token);
            }
            catch
            {
                await transaction.RollbackAsync(token);
                throw;
            }

            return true;
        }

        public async Task<BillDto> GetBillAsync(long orderId, CancellationToken token = default)
        {
            var order = await _context.Orders
                .Include(x=> x.OrderPositions)
                .ThenInclude(x=> x.MenuPosition)
                .FirstOrDefaultAsync(x=> x.Id == orderId, token);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            var bill = new BillDto
            {
                CreateDate = order.CreateDate,
                Amount = order.OrderPositions.Sum(x=> x.MenuPosition.Price),
                Positions = order.OrderPositions
                    .Select(x => new OrderPositionDto
                    {
                        MenuPositionName = x.MenuPosition.Name,
                        Price = x.MenuPosition.Price
                    })
                    .ToArray()                
            };

            return bill;
        }
    }
}
