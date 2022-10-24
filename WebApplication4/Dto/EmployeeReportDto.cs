namespace WebApplication4.Dto
{
    public class EmployeeReportDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public long Surname { get; set; }
        public OrderDto[] Orders { get; set; }
    }
}
