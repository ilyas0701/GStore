
namespace GameStore.Models
{
    public class DbGenre
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<DbGame> Games { get; set; } = [];
    }
}
