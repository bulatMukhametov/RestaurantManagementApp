using WebApplication4.Data;
using WebApplication4.Dto;

namespace WebApplication4.Services
{
    public class EmployeeReportService
    {
        private readonly Context _context;

        public EmployeeReportService(Context context)
        {
            _context = context;
        }

        public async Task<EmployeeReportDto> GetReportAsync()
        {
            throw new NotImplementedException();
        }
    }
}
