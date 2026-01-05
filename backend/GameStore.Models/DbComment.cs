
namespace GameStore.Models
{
    public class DbComment
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string Body { get; set; } = null!;
        
        public int GameId { get; set; }
        
        public DbGame Game { get; set; } = null!;

        public int? ParentId { get; set; }
        
        public DbComment? Parent { get; set; }
        
        public List<DbComment> Replies { get; set; } = [];
    }
}
