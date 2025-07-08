
namespace GameStore.Models
{
    public class DbGenre
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public int? ParentGenreId { get; set; }
        
        public DbGenre? ParentGenre { get; set; }

        public List<DbGenre> SubGenres { get; set; } = [];

        public List<DbGame> Games { get; set; } = [];
    }
}
