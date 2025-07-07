using GameStore.DAL.Abstract;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL.Repositories
{
    public class CommentRepository : EFGenericRepository<DbComment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
        // Additional methods specific to DbComment can be added here if needed
    }
}
