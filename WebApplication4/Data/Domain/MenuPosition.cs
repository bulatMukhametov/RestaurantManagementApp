using WebApplication4.Data.Interfaces;

namespace WebApplication4.Data.Domain
{
    public class MenuPosition: IHaveId
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<OrderPosition> OrderPositions { get; set; }
        public virtual ICollection<ProductInMenuPosition> ProductInMenuPositions { get; set; }
    }
}
