using WebApplication4.Data.Interfaces;

namespace WebApplication4.Data.Domain
{
    public class OrderPosition : IHaveId
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long MenuPositionId { get; set; }
        public virtual Order Order { get; set; }
        public virtual MenuPosition MenuPosition { get; set; }
    }
}
