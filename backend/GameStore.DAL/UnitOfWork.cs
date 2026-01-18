using GameStore.DAL.Abstract;
using GameStore.DAL.Repositories;

namespace GameStore.DAL
{
    public class UnitOfWork(GStoreDatabaseContext context) : IUnitOfWork
    {
        private readonly GStoreDatabaseContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public IGameRepository GameRepository { get; } = new GameRepository(context);
        public ICommentRepository CommentRepository { get; } = new CommentRepository(context);
        public IGenreRepository GenreRepository { get; } = new GenreRepository(context);
        public IPlatformTypeRepository PlatformTypeRepository { get; } = new PlatformTypeRepository(context);
        public IOrderRepository OrderRepository { get; } = new OrderRepository(context);
        public IPublisherRepository PublisherRepository { get; } = new PublisherRepository(context);

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
