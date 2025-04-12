namespace Order.Domain.Common.Interfaces;

public interface IValueObject {
    bool Equals(object? obj);
    int GetHashCode();
}






