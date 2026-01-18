using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class PublisherRepository(DbContext context) : EfGenericRepository<DbPublisher>(context), IPublisherRepository
    {
    }
}
