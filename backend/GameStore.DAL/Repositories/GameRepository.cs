using System.Linq.Expressions;
using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class GameRepository(DbContext context) : EfGenericRepository<DbGame>(context), IGameRepository
    {
        public override async Task<IEnumerable<DbGame>> GetAsync(CancellationToken cancellationToken)
        {
            return await context.Set<DbGame>()
                .Include(g => g.Publisher)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public override async Task<DbGame?> FindById(int id, CancellationToken cancellationToken)
        {
            return await context.Set<DbGame>()
                .Include(g => g.Publisher)
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }
    }
}
