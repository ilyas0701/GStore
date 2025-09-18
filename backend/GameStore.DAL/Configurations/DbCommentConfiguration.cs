

using GameStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Configurations
{
    public class DbCommentConfiguration : IEntityTypeConfiguration<DbComment>
    {
        public void Configure(EntityTypeBuilder<DbComment> builder)
        {
            builder.ToTable("Comments");

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Body)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.ParentId)
                .IsRequired(false);

            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Game)
                .WithMany(g => g.Comments)
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
