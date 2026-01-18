using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Configurations
{
    public class DbPublisherConfiguration : IEntityTypeConfiguration<DbPublisher>
    {
        public void Configure(EntityTypeBuilder<DbPublisher> builder)
        {
            builder.ToTable("Publishers");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.HomePage)
                .HasMaxLength(200);

            builder.HasMany(p => p.Games)
                .WithOne(p => p.Publisher)
                .HasForeignKey(p => p.PublisherId);
        }
    }
}
