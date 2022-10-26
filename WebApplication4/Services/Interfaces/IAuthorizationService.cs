namespace ReastaurantManagement.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<bool> LoginAsync(string login, string password, CancellationToken token = default);
        public Task<bool> LogoutAsync(CancellationToken token = default);
    }
}
