﻿namespace GameStore.DAL.Abstract
{
    public interface IUnitOfWork
    {
        IGameRepository GameRepository { get; }
        ICommentRepository CommentRepository { get; }
        IGenreRepository GenreRepository { get; }
        IPlatformTypeRepository PlatformTypeRepository { get; }
        // Add other repositories as needed, e.g., IUserRepository, IOrderRepository, etc.
        Task CommitAsync(CancellationToken cancellationToken);
    }
} 
