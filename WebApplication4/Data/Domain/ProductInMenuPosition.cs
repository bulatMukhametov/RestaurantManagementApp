namespace WebApplication4.Data.Domain
{
    public class ProductInMenuPosition
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long MenuPositionId { get; set; }
        public virtual Product Product { get; set; }
        public virtual MenuPosition MenuPosition { get; set; }
    }
}
