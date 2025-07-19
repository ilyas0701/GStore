using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        Task<TEntity> FindById(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
