using Order.Domain.Common;
using Order.Domain.Common.Interfaces;

namespace Order.Domain.Entities;

public class ShoppingCartItem: IEntity
{
    private ShoppingCartItem() { }

    public ShoppingCartItem(string shoppingCartId, int productId, string productName, decimal price, int quantity)
    {
        AssertionConcern.AssertArgumentNotNull(shoppingCartId, nameof(shoppingCartId));
        AssertionConcern.AssertArgumentNotNull(productName, nameof(productName));

        ShoppingCartId = shoppingCartId;
        ProductId = productId;
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
    public string Id { get; set; } = default!;
    public string? ShoppingCartId { get; private set; }
    public int ProductId { get; private set; }
    public string ProductName { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}
