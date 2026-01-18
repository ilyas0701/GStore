using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class OrderRepository(DbContext context) : EfGenericRepository<DbOrder>(context), IOrderRepository
    {
    }
}
