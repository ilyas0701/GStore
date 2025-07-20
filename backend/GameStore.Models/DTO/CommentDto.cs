
namespace GameStore.Models.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Body { get; set; } = null!;
        public int GameId { get; set; }
    }
}
