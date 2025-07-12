using GameStore.DAL.Configurations;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DAL
{
    public class GStoreDatabaseContext(DbContextOptions<GStoreDatabaseContext> options) : DbContext(options)
    {
        public DbSet<DbGame> Games { get; set; }
        public DbSet<DbComment> Comments { get; set; }
        public DbSet<DbGenre> Genres { get; set; }
        public DbSet<DbPlatformType> PlatformTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DbGameConfiguration());
            modelBuilder.ApplyConfiguration(new DbCommentConfiguration());
            modelBuilder.ApplyConfiguration(new DbGenreConfiguration());
            modelBuilder.ApplyConfiguration(new DbPlatformTypeConfiguration());

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbGenre>().HasData(SeedHelper.SeedJsonData<DbGenre>("Genres"));
            modelBuilder.Entity<DbPlatformType>().HasData(SeedHelper.SeedJsonData<DbPlatformType>("PlatformTypes"));
        }
    }
}
