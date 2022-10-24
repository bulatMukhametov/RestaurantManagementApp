using WebApplication4.Data;
using WebApplication4.Dto;

namespace WebApplication4.Services
{
    public class MenuReportService
    {
        private readonly Context _context;

        public MenuReportService(Context context)
        {
            _context = context;
        }

        public async Task<MenuDto[]> GetReportAsync(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
