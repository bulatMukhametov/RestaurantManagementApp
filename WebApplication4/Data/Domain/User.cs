namespace WebApplication4.Data.Domain
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public long Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
