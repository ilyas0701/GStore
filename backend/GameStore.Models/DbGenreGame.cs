
namespace GameStore.Models
{
    public class DbGenreGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public DbGame Game { get; set; } = null!;

        public int GenreId { get; set; }
        public DbGenre Genre { get; set; } = null!;

    }
}
