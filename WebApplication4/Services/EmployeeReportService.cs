using WebApplication4.Data;
using WebApplication4.Dto;

namespace WebApplication4.Services
{
    public class EmployeeReportService
    {
        private readonly RestaurantContext _context;

        public EmployeeReportService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<EmployeeReportDto> GetReportAsync()
        {
            throw new NotImplementedException();
        }
    }
}
