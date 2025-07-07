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
            GenreGameRepository = new GenreGameRepository(context);
            PlatformTypeRepository = new PlatformTypeRepository(context);
            PlatformTypeGameRepository = new PlatformTypeGameRepository(context);
        }
        public IGameRepository GameRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IGenreGameRepository GenreGameRepository { get; }
        public IPlatformTypeRepository PlatformTypeRepository { get; }
        public IPlatformTypeGameRepository PlatformTypeGameRepository { get; }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
