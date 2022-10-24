namespace WebApplication4.Dto
{
    public class BillDto
    {
        public DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }
        public OrderPositionDto[] Positions { get; set; }
    }
}
