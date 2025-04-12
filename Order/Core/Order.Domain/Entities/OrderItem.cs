using Order.Domain.Common.Interfaces;

namespace Order.Domain.Entities;

public class OrderItem : IEntity
{
    private OrderItem()
    {
        
    }
    public OrderItem(int orderId, int productId, string? productName, decimal price, int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }

    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public int ProductId { get; set; }
    public string? ProductName { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public override bool Equals(object? obj) => obj is OrderItem item && Id == item.Id;
    public override int GetHashCode() => HashCode.Combine(Id);
    public virtual Order? Order { get; set; }
}





