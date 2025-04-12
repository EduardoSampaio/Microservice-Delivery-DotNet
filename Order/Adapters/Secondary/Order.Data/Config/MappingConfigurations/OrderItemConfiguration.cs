using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities;

namespace Order.Data.Config.MappingConfigurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
        builder.HasKey(oi => oi.Id);
        builder.Property(oi => oi.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(oi => oi.ProductId)
            .IsRequired();
        builder.Property(oi => oi.ProductName)
            .IsRequired();
        builder.Property(oi => oi.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(oi => oi.Quantity)
            .IsRequired();

        builder.HasOne(oi => oi.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(oi => oi.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
