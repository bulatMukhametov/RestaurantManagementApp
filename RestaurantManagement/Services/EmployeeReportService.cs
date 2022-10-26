using ReastaurantManagement.Data;
using ReastaurantManagement.Dto;
using RestaurantManagment.Services.Interfaces;

namespace ReastaurantManagement.Services
{
    public class EmployeeReportService: IReportService
    {
        private readonly RestaurantContext _context;

        public EmployeeReportService(RestaurantContext context)
        {
            _context = context;
        }
    }
}
