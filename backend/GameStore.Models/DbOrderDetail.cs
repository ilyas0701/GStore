namespace GameStore.Models
{
    public class DbOrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DbGame Product { get; set; } = null!;
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }
        public int OrderId { get; set; }
        public DbOrder Order { get; set; } = null!;
    }
}
