using Microsoft.EntityFrameworkCore;
using Piko.Models.Entities;


namespace Piko.Database
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Contest> Contests { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ContestConfiguration());
            modelBuilder.ApplyConfiguration(new UserContestConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}