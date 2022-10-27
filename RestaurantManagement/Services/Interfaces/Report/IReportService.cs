using ReastaurantManagement.Dto;
using RestaurantManagement.Dto;

namespace RestaurantManagment.Services.Interfaces
{
    public interface IReportService
    {
        public Task<ProductReportDto[]> GetProductsReportAsync();
        public Task<EmployeeReportDto[]> GetEmployeeReportAsync(DateTime from, DateTime to);
        public Task<MenuReportDto[]> GetMenuReportAsync(DateTime date);
    }
}
