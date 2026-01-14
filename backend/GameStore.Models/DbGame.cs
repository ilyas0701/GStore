namespace GameStore.Models
{
    public class DbGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Developer { get; set; } = null!;
        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public int PublisherId { get; set; }
        public DbPublisher Publisher { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public DateTime ReleaseAtDate { get; set; }
        public List<DbComment> Comments { get; set; } = [];
        public List<DbGenre> Genres { get; set; } = [];
        public List<DbPlatformType> PlatformTypes { get; set; } = [];  
    }
}
