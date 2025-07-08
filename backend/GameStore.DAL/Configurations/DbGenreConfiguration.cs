using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GameStore.DAL.Configurations
{
    public class DbGenreConfiguration : IEntityTypeConfiguration<DbGenre>
    {
        public void Configure(EntityTypeBuilder<DbGenre> builder)
        {
            builder.ToTable("Genres");

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(g => g.Games)
                .WithMany(g => g.Genres);
        }
    }
}
