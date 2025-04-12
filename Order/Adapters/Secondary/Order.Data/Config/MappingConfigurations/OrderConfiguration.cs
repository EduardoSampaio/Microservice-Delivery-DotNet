using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities;

namespace Order.Data.Config.MappingConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.OrderStatus).HasConversion<string>();

            builder.Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.OwnsOne(o => o.Address, a =>
            {
                a.Property(x => x.AddressLine).HasColumnName("addressLine");
                a.Property(x => x.State).HasColumnName("state");
                a.Property(x => x.Country).HasColumnName("Country");
                a.Property(x => x.ZipCode).HasColumnName("zipCode");
            });

            builder.OwnsOne(o => o.Customer, c =>
            {
                c.Property(x => x.CustomerName).HasColumnName("customerName");
                c.Property(x => x.CustomerId).HasColumnName("customerId");
                c.Property(x => x.CustomerEmail).HasColumnName("customerEmail");
                c.Property(x => x.CustomerPhone).HasColumnName("customerPhone");
            });

            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);
        }
    }
}
