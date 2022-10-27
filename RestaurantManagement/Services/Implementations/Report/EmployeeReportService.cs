using Microsoft.EntityFrameworkCore;
using ReastaurantManagement.Data;
using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Services
{
    public class EmployeeReportService
    {
        private readonly RestaurantContext _dbContext;

        public EmployeeReportService(RestaurantContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeReportDto[]> GetReportAsync(DateTime from, DateTime to)
        {
            return await _dbContext.Employees
                .Include(x => x.User)
                .Include(x => x.Orders)                
                .Select(x => new EmployeeReportDto
                {
                    Id = x.Id,
                    FirstName = x.User.FirstName,
                    Surname = x.User.Surname,
                    Orders = x.Orders
                        .Where(y => y.CreateDate >= from && y.CreateDate <= to)
                        .Select(y => new OrderDto
                        {
                            Id = y.Id,
                            CreateDate = y.CreateDate,
                            CustomerId = y.CustomerId,
                        }).ToArray(),

                })
                .ToArrayAsync();               
        }
    }
}
