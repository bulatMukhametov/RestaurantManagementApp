using WebApplication4.Data.Interfaces;

namespace WebApplication4.Data.Domain
{
    public class Order : IHaveId, IHaveCreateDate
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public long CustomerId { get; set; }
        public long EmployeeId { get; set; }
        public virtual Customer Customer { get; set; } 
        public virtual Employee Employee { get; set; }
        public virtual ICollection<OrderPosition> OrderPositions { get; set; }
        
    }
}
