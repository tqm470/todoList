using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entity;
using TodoApp.Infra.Map;

namespace TodoApp.Infra
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Item { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>(new ItemMap().Configure);
        }
    }
}