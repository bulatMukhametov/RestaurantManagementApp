using ReastaurantManagement.Data.Interfaces;

namespace ReastaurantManagement.Data.Domain
{
    public class Order : IEntity, IHaveCreateDate
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public long CustomerId { get; set; }
        public long EmployeeId { get; set; }
        public bool IsPayed { get; set; }
        public virtual Customer Customer { get; set; } 
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderPosition> OrderPositions { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }

    }
}
