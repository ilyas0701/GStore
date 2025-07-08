using GameStore.DAL.Abstract;
using GameStore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            GameRepository = new GameRepository(context);
            CommentRepository = new CommentRepository(context);
            GenreRepository = new GenreRepository(context);
            PlatformTypeRepository = new PlatformTypeRepository(context);
        }
        public IGameRepository GameRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IPlatformTypeRepository PlatformTypeRepository { get; }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
