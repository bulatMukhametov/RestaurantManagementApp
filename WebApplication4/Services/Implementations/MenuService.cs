using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Data.Domain;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services
{
    public class MenuService: IMenuService
    {
        private readonly Context _context;

        public MenuService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuPosition>> GetActualMenuAsync(CancellationToken token = default)
        {
            return await _context.MenuPositions
                .Where(x=> x.IsActive)
                .ToListAsync(token);
        }

        public async Task AddAsync(CancellationToken token = default)
        {
            var newMenuPosition = new MenuPosition();
            await _context.AddAsync<MenuPosition>(newMenuPosition, token);
            await _context.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(CancellationToken token = default)
        {
            var newMenuPosition = new MenuPosition();
            await _context.SaveChangesAsync(token);
        }

        public async Task RemoveAsync(long id, CancellationToken token = default)
        {
            _context.MenuPositions.Remove(new MenuPosition());
            await _context.SaveChangesAsync(token);
        }
    }
}
