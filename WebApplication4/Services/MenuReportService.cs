using ReastaurantManagement.Data;
using ReastaurantManagement.Dto;

namespace ReastaurantManagement.Services
{
    public class MenuReportService
    {
        private readonly RestaurantContext _context;

        public MenuReportService(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<MenuPositionDto[]> GetReportAsync(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
