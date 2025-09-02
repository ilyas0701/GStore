using GameStore.BLL.Abstract;
using GameStore.DAL.Abstract;
using GameStore.Models;
using GameStore.Models.DTO;
using GameStore.Utils.Exceptions;

namespace GameStore.BLL;

public class CommentService(IUnitOfWork unitOfWork) : ICommentService
{
    public async Task CreateCommentAsync(CommentDto commentDto, CancellationToken cancellationToken)
    {
        var game = await unitOfWork.GameRepository.FindById(commentDto.GameId);
            
        if (game == null)
        {
            throw new NotFoundException($"Game with id {commentDto.GameId} not found.");
        }

        var comment = new DbComment
        {
            GameId = commentDto.GameId,
            Name = commentDto.Name,
            Body = commentDto.Body
        };

        unitOfWork.CommentRepository.Create(comment);
        await unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task<IEnumerable<CommentDto>?> GetCommentAsync(int gameId, CancellationToken cancellationToken)
    {
        var comments = await unitOfWork.CommentRepository.GetAsync(g => gameId == g.GameId, cancellationToken);
            
        return comments?.Select(c => new CommentDto
        {
            Id = c.Id,
            GameId = c.GameId,
            Name = c.Name,
            Body = c.Body
        });
    }
}