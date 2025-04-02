using Microsoft.EntityFrameworkCore;
using Payments.Entities;

namespace Payments.Data.Data;

public class AppDbContext : DbContext
{
    public DbSet<Payment> Payments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Payment");
    }
}
