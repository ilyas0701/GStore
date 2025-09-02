using System.Linq.Expressions;

namespace GameStore.DAL.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        Task<TEntity?> FindById(int id);
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
