using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameStore.DAL.Abstract
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        ICommentRepository CommentRepository { get; }
        // Add other repositories as needed, e.g., IUserRepository, IOrderRepository, etc.
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
