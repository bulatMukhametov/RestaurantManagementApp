namespace WebApplication4.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public Task Login(string login, string password);
        public Task Logout();
    }
}
