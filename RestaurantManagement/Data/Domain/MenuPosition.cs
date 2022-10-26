using ReastaurantManagement.Data.Interfaces;

namespace ReastaurantManagement.Data.Domain
{
    public class MenuPosition: IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<OrderPosition> OrderPositions { get; set; }
        public virtual ICollection<ProductInMenuPosition> ProductInMenuPositions { get; set; }
    }
}
