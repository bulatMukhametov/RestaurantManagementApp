using ReastaurantManagement.Dto;
using ReastaurantManagement.Services;
using RestaurantManagement.Dto;
using RestaurantManagment.Services.Interfaces;

namespace RestaurantManagement.Services.Implementations.Report
{
    public class ReportService : IReportService
    {
        private readonly EmployeeReportService _employeeReportService;
        private readonly ProductReportService _productReportService;
        private readonly MenuReportService _menuReportService;

        public ReportService(EmployeeReportService employeeReportService,
            ProductReportService productReportService, MenuReportService menuReportService)
        {
            _employeeReportService = employeeReportService;
            _productReportService = productReportService;
            _menuReportService = menuReportService;
        }

        public async Task<EmployeeReportDto[]> GetEmployeeReportAsync(DateTime from, DateTime to)
        {
            return await _employeeReportService.GetReportAsync(from, to);
        }

        public async Task<MenuReportDto[]> GetMenuReportAsync(DateTime date)
        {
            return await _menuReportService.GetReportAsync(date);
        }

        public async Task<ProductReportDto[]> GetProductsReportAsync()
        {
            return await _productReportService.GetReportAsync();
        }
    }
}
