using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReastaurantManagement.Dto;
using RestaurantManagement.Constants;
using RestaurantManagement.Dto;
using RestaurantManagment.Services.Interfaces;

namespace ReastaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = ProjectConstants.AdminRoleName)]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }


        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>ProductReportDto[]</returns>
        [HttpGet("GetProductsReport")]
        public async Task<ProductReportDto[]> GetProductsReport()
        {
            return await _reportService.GetProductsReportAsync();
        }

        /// <summary>
        /// Get report about employees' orders 
        /// </summary>
        /// <returns>EmployeeReportDto[]</returns>
        [HttpGet("GetEmployeeReport")]
        public async Task<EmployeeReportDto[]> GetEmployeeReport(DateTime from, DateTime to)
        {
            return await _reportService.GetEmployeeReportAsync(from, to);
        }

        /// <summary>
        /// Get report about menu for date
        /// </summary>
        /// <returns>EmployeeReportDto[]</returns>
        [HttpGet("GetMenuReport")]
        public async Task<MenuReportDto[]> GetMenuReport(DateTime date)
        {
            return await _reportService.GetMenuReportAsync(date);
        }
    }
}
