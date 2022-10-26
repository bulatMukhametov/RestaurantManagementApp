namespace ReastaurantManagement.Data.Domain
{
    public class Bill
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Amount { get; set; }
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
