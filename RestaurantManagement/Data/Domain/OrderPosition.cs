using ReastaurantManagement.Data.Interfaces;

namespace ReastaurantManagement.Data.Domain
{
    public class OrderPosition : IEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long MenuPositionId { get; set; }
        public virtual Order Order { get; set; }
        public virtual MenuPosition MenuPosition { get; set; }
    }
}
