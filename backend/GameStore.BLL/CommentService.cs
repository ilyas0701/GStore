using GameStore.BLL.Abstract;
using GameStore.DAL.Abstract;
using GameStore.Models;
using GameStore.Models.DTO;
using GameStore.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            ParentId = commentDto.ParentId,
            Name = commentDto.Name,
            Body = commentDto.Body
        };

        unitOfWork.CommentRepository.Create(comment);
        await unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task<IEnumerable<CommentDto>?> GetCommentAsync(int gameId, CancellationToken cancellationToken)
    {
        var allComments = await unitOfWork.CommentRepository
            .GetQueryable(g => gameId == g.GameId)
            .Include(c => c.Replies)
            .ToListAsync(cancellationToken);

        var commentLookup = allComments.ToDictionary(c => c.Id);

        var rootComments = allComments
            .Where(c => c.ParentId == null)
            .Select(c => MapToDtoWithReplies(c, commentLookup))
            .ToList();

        return rootComments;
    }

    private CommentDto MapToDtoWithReplies(DbComment comment, Dictionary<int, DbComment> commentLookup)
    {
        var replies = commentLookup.Values
            .Where(c => c.ParentId == comment.Id)
            .Select(c => MapToDtoWithReplies(c, commentLookup))
            .ToList();

        return new CommentDto(
            comment.Id,
            comment.GameId,
            comment.ParentId,
            comment.Name,
            comment.Body,
            replies
        );
    }
}