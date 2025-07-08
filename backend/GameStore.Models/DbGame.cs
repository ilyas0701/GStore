namespace GameStore.Models
{
    public class DbGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Developer { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime ReleaseAtDate { get; set; }
    }
}
