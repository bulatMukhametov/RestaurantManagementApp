using ReastaurantManagement.Data.Interfaces;

namespace ReastaurantManagement.Data.Domain
{
    public class Product : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ProductInMenuPosition> ProductInMenuPositions { get; set; }
    }
}
