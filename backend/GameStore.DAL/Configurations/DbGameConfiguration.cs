
using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Configurations
{
    public class DbGameConfiguration : IEntityTypeConfiguration<DbGame>
    {
        public void Configure(EntityTypeBuilder<DbGame> builder)
        {
            builder.ToTable("Games");

            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(g => g.Developer)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(g => g.ImgUrl).HasMaxLength(300);

            builder.Property(g => g.ReleaseAtDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasMany(g => g.Comments)
                .WithOne(c => c.Game)
                .HasForeignKey(builder => builder.GameId);

            builder.HasMany(g => g.Genres)
                .WithMany(g => g.Games);

            builder.HasMany(g => g.PlatformTypes)
                .WithMany(p => p.Games);
        }
    }
}
