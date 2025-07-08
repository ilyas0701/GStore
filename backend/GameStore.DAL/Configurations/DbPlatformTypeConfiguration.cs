using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Configurations
{
    public class DbPlatformTypeConfiguration : IEntityTypeConfiguration<DbPlatformType>
    {
        public void Configure(EntityTypeBuilder<DbPlatformType> builder)
        {
            builder.ToTable("PlatformTypes");
            builder.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasMany(p => p.Games)
                .WithMany(g => g.PlatformTypes);
        }
    }
}
