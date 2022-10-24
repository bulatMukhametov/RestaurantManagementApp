namespace WebApplication4.Dto
{
    public class OrderDto
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public long CustomerId { get; set; }
        public long EmployeeId { get; set; }
        public long [] MenuPositionIds { get; set; }
    }
}
