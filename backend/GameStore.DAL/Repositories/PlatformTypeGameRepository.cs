using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;


namespace GameStore.DAL.Repositories
{
    public class PlatformTypeGameRepository : EFGenericRepository<DbPlatformTypeGame>, IPlatformTypeGameRepository
    {
        public PlatformTypeGameRepository(DbContext context) : base(context)
        {
        }
    }
}
