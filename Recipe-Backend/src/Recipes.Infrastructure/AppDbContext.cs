using Domain.Users;
using Domain.Recipes;
using Domain.Likes;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Like> Likes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
        modelBuilder.Entity<Like>().HasKey(l => l.Id);

        base.OnModelCreating(modelBuilder);
    }
}
