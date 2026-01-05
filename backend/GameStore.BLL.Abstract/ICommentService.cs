using GameStore.Models.DTO;

namespace GameStore.BLL.Abstract;

public interface ICommentService
{
    Task CreateCommentAsync(CommentDto commentDto, CancellationToken cancellationToken);

    Task<IEnumerable<CommentDto>?> GetCommentAsync(int gameId, CancellationToken cancellationToken);
}