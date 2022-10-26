namespace ReastaurantManagement.Dto
{
    public class MenuPositionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
