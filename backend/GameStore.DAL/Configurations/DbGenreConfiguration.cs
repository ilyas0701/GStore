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

            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(g => g.Name)
                .IsUnique();

            builder.HasMany(g => g.Games)
                .WithMany(g => g.Genres);
        }
    }
}
