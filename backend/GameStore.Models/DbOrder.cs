namespace GameStore.Models
{
    public class DbOrder
    {
        public int Id { get; set; }
        public required string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<DbOrderDetail> OrderDetails { get; set; } = [];
    }
}
