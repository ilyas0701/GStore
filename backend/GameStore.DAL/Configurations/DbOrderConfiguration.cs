using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Configurations
{
    public class DbOrderConfiguration : IEntityTypeConfiguration<DbOrder>
    {
        public void Configure(EntityTypeBuilder<DbOrder> builder)
        {
            builder.ToTable("Orders");

            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.Property(o => o.CustomerId)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.HasMany(o => o.OrderDetails)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
