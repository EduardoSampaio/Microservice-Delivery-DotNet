using Order.Domain.Common.Interfaces;

namespace Order.Domain.Entities;

public class ShoppingCartItem: IEntity
{
    public ShoppingCartItem(int shoppingCartId, int productId, string? productName, decimal price, int quantity)
    {
        ShoppingCartId = shoppingCartId;
        ProductId = productId;
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
    public int Id { get; set; }
    public int ShoppingCartId { get; private set; }
    public int ProductId { get; private set; }
    public string? ProductName { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}
