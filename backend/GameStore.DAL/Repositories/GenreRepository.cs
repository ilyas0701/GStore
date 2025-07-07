using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class GenreRepository : EFGenericRepository<DbGenre>, IGenreRepository
    {
        public GenreRepository(DbContext context) : base(context)
        {
        }
    }
}
