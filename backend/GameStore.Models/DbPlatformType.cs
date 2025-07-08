
namespace GameStore.Models
{
    public class DbPlatformType
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public List<DbGame> Games { get; set; } = [];
    }
}
     