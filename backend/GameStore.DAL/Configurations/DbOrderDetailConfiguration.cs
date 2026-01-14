using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Configurations
{
    public class DbOrderDetailConfiguration : IEntityTypeConfiguration<DbOrderDetail>
    {
        public void Configure(EntityTypeBuilder<DbOrderDetail> builder)
        {
            builder.ToTable("Order Details");

            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.Property(o => o.Discount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
