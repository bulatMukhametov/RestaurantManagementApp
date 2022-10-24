namespace WebApplication4.Data.Domain
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ProductInMenuPosition> ProductInMenuPositions { get; set; }
    }
}
