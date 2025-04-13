using Order.Domain.Common;
using Order.Domain.Common.Interfaces;
using Order.Domain.ValueObject;

namespace Order.Domain.Entities;

public class BasketCheckout: IEntity
{
    private BasketCheckout() {}

    public BasketCheckout(CustomerVO customer, PaymentVO payment, AddressVO address, string shoppingCartId)
    {
        AssertionConcern.AssertArgumentNotNull(customer, nameof(customer));
        AssertionConcern.AssertArgumentNotNull(payment, nameof(payment));
        AssertionConcern.AssertArgumentNotNull(address, nameof(address));
        AssertionConcern.AssertArgumentNotNull(shoppingCartId, nameof(shoppingCartId));
        AssertionConcern.AssertArgumentNotEmpty(shoppingCartId, nameof(shoppingCartId));

        Customer = customer;
        Payment = payment;
        Address = address;
        ShoppingCartId = shoppingCartId;
    }

    public string Id { get; private set; } = default!;
    public string? ShoppingCartId { get; set; }
    public CustomerVO? Customer { get; private set; }
    public PaymentVO? Payment { get; private set; }
    public AddressVO? Address { get; private set; }
}
