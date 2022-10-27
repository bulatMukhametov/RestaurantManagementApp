using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data;
using ReastaurantManagement.Data.Domain;
using ReastaurantManagement.Dto;
using ReastaurantManagement.Services.Interfaces;

namespace ReastaurantManagement.Services
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantContext _dbContext;

        public OrderService(RestaurantContext context)
        {
            _dbContext = context;
        }

        public async Task<OrderDto> GetOrderAsync(long id, CancellationToken token = default)
        {
            var order = await _dbContext.Orders
                .Include(x => x.OrderPositions)
                .FirstOrDefaultAsync(x => x.Id == id, token);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return new OrderDto
            {
                Id = order.Id,
                CreateDate = order.CreateDate,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                MenuPositionIds = order.OrderPositions.Select(x => x.MenuPositionId).ToArray()
            };
        }

        public async Task<bool> CreateOrderAsync(OrderDto orderDto, CancellationToken token = default)
        {
            //TODO Model validating
            
            using var transaction = await _dbContext.Database.BeginTransactionAsync(token);
            
            try
            {
                var newOrder = new Order
                {
                    CreateDate = orderDto.CreateDate,
                    CustomerId = orderDto.CustomerId,
                    EmployeeId = orderDto.EmployeeId,
                };

                await _dbContext.AddAsync(newOrder, token);
                await _dbContext.SaveChangesAsync(token);

                foreach (var menuPositionId in orderDto.MenuPositionIds)
                {
                    var newOrderPosition = new OrderPosition
                    {
                        MenuPositionId = menuPositionId,
                        OrderId = newOrder.Id
                    };
                    await _dbContext.AddAsync(newOrderPosition, token);
                }

                await _dbContext.SaveChangesAsync(token);
                await transaction.CommitAsync(token);
            }
            catch(Exception ex)
            {
                //TODO Log ex
                //await transaction.RollbackAsync(token);
                throw;
            }

            return true;
        }

        public async Task<BillDto> PayForOrderAsync(long id, CancellationToken token = default)
        {
            var order = await _dbContext.Orders
                .Include(x => x.OrderPositions)
                .ThenInclude(x => x.MenuPosition)
                .FirstOrDefaultAsync(x => x.Id == id, token);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync(token);

            try
            {
                order.IsPayed = true;
                
                var bill = await CreateBillAsync(order, token);
                
                await _dbContext.SaveChangesAsync(token);
                await transaction.CommitAsync(token);

                var billDto = new BillDto
                {
                    CreateDate = bill.CreateDate,
                    Amount = bill.Amount,
                    Positions = order.OrderPositions
                    .Select(x => new OrderPositionDto
                    {
                        MenuPositionName = x.MenuPosition.Name,
                        Price = x.MenuPosition.Price
                    })
                    .ToArray()
                };

                return billDto;
            }
            catch (Exception ex)
            {
                //TODO Log ex
                await transaction.RollbackAsync(token);
                throw;
            }
        }

        private async Task<Bill> CreateBillAsync(Order order, CancellationToken token)
        {
            var bill = new Bill
            {
                CreateDate = DateTime.UtcNow,
                OrderId = order.Id,
                Amount = order.OrderPositions.Sum(x => x.MenuPosition.Price),
            };

            await _dbContext.AddAsync(bill, token);

            return bill;
        }
    }
}
