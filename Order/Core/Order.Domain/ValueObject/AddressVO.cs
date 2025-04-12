using Order.Domain.Common.Interfaces;

namespace Order.Domain.ValueObject;

public sealed class AddressVO: IEquatable<AddressVO>,  IValueObject
{

    public string AddressLine { get; }
    public string Country { get; }
    public string State { get; }
    public string ZipCode { get; }

    public AddressVO(string addressLine, string country, string state, string zipCode)
    {
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public bool Equals(AddressVO? other)
    {
        if (other is null)
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        return AddressLine.Equals(other.AddressLine) && Country.Equals(other.Country) && State.Equals(other.State) && ZipCode.Equals(other.ZipCode);
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
        return Equals((AddressVO)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AddressLine, Country, State, ZipCode);
    }

    public static bool operator ==(AddressVO? left, AddressVO? right)
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

    public static bool operator !=(AddressVO? left, AddressVO? right)
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
