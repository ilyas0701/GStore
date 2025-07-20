namespace GameStore.Web.Models.Responses
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
