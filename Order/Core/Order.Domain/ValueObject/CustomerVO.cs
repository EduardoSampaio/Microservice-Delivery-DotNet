using Order.Domain.Common.Interfaces;

namespace Order.Domain.ValueObject;

public sealed class CustomerVO: IValueObject, IEquatable<CustomerVO>
{
    public string? CustomerName { get; }
    public string? CustomerEmail { get; }
    public string? CustomerPhone { get;}
    public Guid CustomerId { get;}

    public CustomerVO(string? customerName, string? customerEmail, string? customerPhone, Guid customerId)
    {
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
        CustomerId = customerId;
    }

    public bool Equals(CustomerVO? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return CustomerId.Equals(other.CustomerId);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((CustomerVO)obj);
    }
    public override int GetHashCode() => CustomerId.GetHashCode();

    public static bool operator ==(CustomerVO? left, CustomerVO? right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(CustomerVO? left, CustomerVO? right)
    {
        return !(left == right);
    }
}






