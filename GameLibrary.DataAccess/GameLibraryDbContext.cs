using GameLibrary.DataAccess.Configurations;
using GameLibrary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.DataAccess
{
    public class GameLibraryDbContext(DbContextOptions<GameLibraryDbContext> options) : DbContext(options) 
    {
        public DbSet<GameEntity> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
