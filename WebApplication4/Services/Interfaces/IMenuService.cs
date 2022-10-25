namespace WebApplication4.Services.Interfaces
{
    public interface IMenuService
    {
        public Task CreateMenuPositionAsync(CancellationToken token = default);
        public Task RemoveAsync(long id, CancellationToken token = default);
        public Task UpdateAsync(CancellationToken token = default);
    }
}
