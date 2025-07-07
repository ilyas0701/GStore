
using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class GenreGameRepository : EFGenericRepository<DbGenreGame>, IGenreGameRepository
    {
        public GenreGameRepository(DbContext context) : base(context)
        {
        }
    }
}
