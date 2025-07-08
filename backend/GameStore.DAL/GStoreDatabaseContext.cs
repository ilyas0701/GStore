using GameStore.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL
{
    public class GStoreDatabaseContext : DbContext
    {
        public GStoreDatabaseContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DbGameConfiguration());
            modelBuilder.ApplyConfiguration(new DbCommentConfiguration());
            modelBuilder.ApplyConfiguration(new DbGenreConfiguration());
            modelBuilder.ApplyConfiguration(new DbPlatformTypeConfiguration());
        }
    }
}
