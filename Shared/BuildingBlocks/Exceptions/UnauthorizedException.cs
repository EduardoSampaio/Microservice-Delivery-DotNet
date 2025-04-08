using System.Net;

namespace BuildingBlocks.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException(List<string>? errorMEssages = default, HttpStatusCode statusCode = HttpStatusCode.Unauthorized)
    {
        ErrorMessages = errorMEssages;
        StatusCode = statusCode;
    }

    public List<string>? ErrorMessages { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
