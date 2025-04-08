using System;
using System.Net;

namespace BuildingBlocks.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(List<string>? errorMEssages = default, HttpStatusCode statusCode = HttpStatusCode.NotFound)
    {
        ErrorMessages = errorMEssages;
        StatusCode = statusCode;
    }

    public List<string>? ErrorMessages { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
