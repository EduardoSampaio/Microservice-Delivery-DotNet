using Order.Domain.Common.Interfaces;
using Order.Domain.Enums;

namespace Order.Domain.ValueObject;

public sealed class PaymentVO : IValueObject, IEquatable<PaymentVO>
{
    public PaymentVO(string? cardName, string? cardNumber, string? expiration, string? cvv, PaymentMethod paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        Cvv = cvv;
        PaymentMethod = paymentMethod;
    }

    public string? CardName { get; }
    public string? CardNumber { get;}
    public string? Expiration { get;}
    public string? Cvv { get;}
    public PaymentMethod PaymentMethod { get;}

    public override bool Equals(object? obj) => base.Equals(obj);
    public bool Equals(PaymentVO? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        return CardNumber!.Equals(other.CardNumber);
    }
    public override int GetHashCode() => CardNumber!.GetHashCode();
    public static bool operator ==(PaymentVO? left, PaymentVO? right)
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

    public static bool operator !=(PaymentVO? left, PaymentVO? right)
    {
        if (left is null && right is null)
        {
            return false;
        }
        if (left is null || right is null)
        {
            return true;
        }
        return !left.Equals(right);
    }
}
