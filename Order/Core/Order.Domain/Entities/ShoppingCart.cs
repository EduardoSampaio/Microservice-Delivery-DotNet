using Order.Domain.Common.Interfaces;
using Order.Domain.Exceptions;

namespace Order.Domain.Entities;

public class ShoppingCart: IAggregateRoot
{
    private ShoppingCart() { }
    public ShoppingCart(Guid customerId, HashSet<ShoppingCartItem> itens)
    {
        CustomerId = customerId;
        Items = itens;
    }

    public int Id { get; private set; }
    public Guid CustomerId { get;}
    public virtual HashSet<ShoppingCartItem> Items { get; private set; } = [];

    public void AddOrderItems(HashSet<ShoppingCartItem> itens)
    {
        foreach (var item in itens)
        {
            var shoppingCartItem = AddShoppingCartItem(item);
            Items.Add(shoppingCartItem);
        }
    }

    private ShoppingCartItem AddShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        var item = Items.FirstOrDefault(x => x.ProductId == shoppingCartItem.ProductId);
        if (item is not null)
        {
            throw new DomainException("Shopping Cart Already exist");
        }
        return shoppingCartItem;
        
    }

    public void UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
    {
        var item = Items.FirstOrDefault(x => x.Id == shoppingCartItem.Id);
        if (item != null)
        {
            item.UpdateQuantity(shoppingCartItem.Quantity);
        }
        else
        {
            throw new DomainException("Shopping Cart item not found");
        }
    }

    public void RemoveShoppingCartItem(ShoppingCartItem item)
    {
        var removed = Items.Remove(item);
        if (!removed)
        {
            throw new DomainException("Shopping Cart item not found");
        }
    }

}
