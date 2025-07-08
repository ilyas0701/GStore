namespace GameStore.DAL.Abstract
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        ICommentRepository CommentRepository { get; }
        IGenreRepository GenreRepository { get; }
        IGenreGameRepository GenreGameRepository { get; }
        IPlatformTypeRepository PlatformTypeRepository { get; }
        IPlatformTypeGameRepository PlatformTypeGameRepository { get; }
        // Add other repositories as needed, e.g., IUserRepository, IOrderRepository, etc.
        Task CommitAsync(CancellationToken cancellationToken);
    }
} 
