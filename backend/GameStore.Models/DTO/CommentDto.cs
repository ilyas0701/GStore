
namespace GameStore.Models.DTO
{
    public record CommentDto(int Id, int GameId, int? ParentId, string Name, string Body, List<CommentDto> Replies);
}
