
namespace GameStore.Models
{
    public class DbPlatformTypeGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public DbGame Game { get; set; } = null!;
        public int PlatformTypeId { get; set; }

    }
}
