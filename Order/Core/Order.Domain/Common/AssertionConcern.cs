﻿using System.Text.RegularExpressions;
using Order.Domain.Exceptions;

namespace Order.Domain.Common;

public class AssertionConcern
{
    public static void AssertArgumentEquals(object object1, object object2, string message)
    {
        if (!object1.Equals(object2))
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentFalse(bool boolValue, string message)
    {
        if (boolValue)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentLength(string stringValue, int maximum, string message)
    {
        int length = stringValue.Trim().Length;
        if (length > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
    {
        int length = stringValue.Trim().Length;
        if (length < minimum || length > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentMatches(string pattern, string stringValue, string message)
    {
        Regex regex = new Regex(pattern);

        if (!regex.IsMatch(stringValue))
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentNotEmpty(string stringValue, string message)
    {
        if (stringValue == null || stringValue.Trim().Length == 0)
        {
            throw new DomainException($"{message} is empty");
        }
    }

    public static void AssertArgumentNotEquals(object object1, object object2, string message)
    {
        if (object1.Equals(object2))
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentNotNull(object object1, string message)
    {
        if (object1 == null)
        {
            throw new DomainException($"{message} is null");
        }
    }

    public static void AssertArgumentRange(double value, double minimum, double maximum, string message)
    {
        if (value < minimum || value > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentRange(float value, float minimum, float maximum, string message)
    {
        if (value < minimum || value > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentRange(int value, int minimum, int maximum, string message)
    {
        if (value < minimum || value > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentRange(long value, long minimum, long maximum, string message)
    {
        if (value < minimum || value > maximum)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertArgumentTrue(bool boolValue, string message)
    {
        if (!boolValue)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertStateFalse(bool boolValue, string message)
    {
        if (boolValue)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertStateTrue(bool boolValue, string message)
    {
        if (!boolValue)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertDateTimeMoreThanOrEqualsToday(DateTime dateTime, string message)
    {
        if (dateTime < DateTime.Now)
        {
            throw new DomainException(message);
        }
    }

    public static void AssertDateTimeCompare(DateTime dateStart, DateTime dateEnd, string message)
    {
        if (dateStart <= dateEnd)
        {
            throw new DomainException(message);
        }
    }
}
