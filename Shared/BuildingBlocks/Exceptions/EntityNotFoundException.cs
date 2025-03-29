using System;

namespace BuildingBlocks.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : base("Entity Not Found")
    {
    }
}
