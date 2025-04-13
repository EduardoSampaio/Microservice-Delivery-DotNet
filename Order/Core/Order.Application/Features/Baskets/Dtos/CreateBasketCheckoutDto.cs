using Order.Domain.Entities;
using Order.Domain.Enums;
using Order.Domain.ValueObject;

namespace Order.Application.Features.Baskets.Dtos;

public class CreateBasketCheckoutDto
{
    public string? ShoppingCartId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }
    public string? CustomerId { get; set; }
    public string? AddressLine { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? CardName { get; set; }
    public string? CardNumber { get; set; }
    public string? Expiration { get; set; }
    public string? Cvv { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    public BasketCheckout ToEntity()
    {
        var customer = new CustomerVO(CustomerName, CustomerEmail, CustomerPhone, Guid.Parse(CustomerId!));
        var payment = new PaymentVO(CardName, CardNumber, Expiration, Cvv, PaymentMethod);
        var address = new AddressVO(AddressLine, Country, State, ZipCode);

        return new BasketCheckout(customer, payment, address, ShoppingCartId);
    }
}
