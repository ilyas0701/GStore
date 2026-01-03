using System.Linq.Expressions;
using GameStore.DAL.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class EfGenericRepository<TEntity>(DbContext context) : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }
        
        public async Task<TEntity?> FindById(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(new object[id], cancellationToken);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }
        
        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }
    }
}
