
using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class PlatformTypeRepository : EfGenericRepository<DbPlatformType>, IPlatformTypeRepository
    {
        public PlatformTypeRepository(DbContext context) : base(context)
        {
        }
        // Additional methods specific to DbPlatformType can be added here if needed
    }
}
