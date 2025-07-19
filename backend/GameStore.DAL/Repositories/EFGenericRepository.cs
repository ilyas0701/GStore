using GameStore.DAL.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public EFGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
        {
            return await Task.Run(() => _dbSet.AsNoTracking().Where(predicate).ToList());
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.AddAsync(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }
    }
}
