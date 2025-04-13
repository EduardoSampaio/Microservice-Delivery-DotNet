using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;

namespace Order.Data.Config;

public class AppDbContext : DbContext
{
    public DbSet<Domain.Entities.Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("OrderService");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
