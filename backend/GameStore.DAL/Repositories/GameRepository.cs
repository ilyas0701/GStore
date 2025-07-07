using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class GameRepository : EFGenericRepository<DbGame>, IGameRepository
    {
        public GameRepository(DbContext context) : base(context)
        {
        }
        // Additional methods specific to DbGame can be added here if needed
    }
}
