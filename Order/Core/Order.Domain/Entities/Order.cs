using Order.Domain.Common;
using Order.Domain.Common.Interfaces;
using Order.Domain.Enums;
using Order.Domain.Exceptions;
using Order.Domain.ValueObject;

namespace Order.Domain.Entities;

public class Order : IAggregateRoot
{
    private Order() { }

    public Order(CustomerVO customer, AddressVO address, HashSet<OrderItem> orderItems)
    {
        AssertionConcern.AssertArgumentNotNull(customer, nameof(customer));
        AssertionConcern.AssertArgumentNotNull(address, nameof(address));

        Customer = customer;
        Address = address;
        OrderStatus = OrderStatus.Pending;
        OrderDate = DateTime.Now;
        OrderItems = orderItems;
    }

    public int Id { get; private set; }
    public CustomerVO? Customer { get; private set; }
    public AddressVO? Address { get; set; }
    public OrderStatus OrderStatus { get; private set; }
    public DateTime OrderDate { get; private set; }
    public decimal TotalAmount
    {
        get
        {
            return OrderItems.Sum(x => x.Price * x.Quantity);
        }
    }
    public virtual HashSet<OrderItem> OrderItems { get; private set; } = [];

    public void UpdateOrderStatus(OrderStatus orderStatus)
    {
        OrderStatus = orderStatus;
    }

    public void UpdateAddress(AddressVO address)
    {
        Address = address;
    }
}



