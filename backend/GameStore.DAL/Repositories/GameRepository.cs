using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class GameRepository(DbContext context) : EfGenericRepository<DbGame>(context), IGameRepository
    {
    }
}
