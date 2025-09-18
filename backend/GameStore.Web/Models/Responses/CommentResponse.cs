namespace GameStore.Web.Models.Responses
{
    public record CommentResponse(int Id, string Name, string Content, int? ParentId);
}
