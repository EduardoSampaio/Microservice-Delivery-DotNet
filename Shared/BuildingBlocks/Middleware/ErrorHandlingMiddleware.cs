using BuildingBlocks.Exceptions;
using BuildingBlocks.Wrappers.http;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace BuildingBlocks.Middleware;
/**
 * ErrorHandlingMiddleware is a custom middleware that handles exceptions thrown during the request processing pipeline.
 * It catches specific exceptions and returns appropriate HTTP responses with error messages.
 */
public class ErrorHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        var responseWrapper = ResponseWrapper.Fail();

        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            responseWrapper.Messages = [.. ex.Errors.Select(e => e.ErrorMessage)];
            var result = JsonSerializer.Serialize(responseWrapper);
            await response.WriteAsync(result);
        }
        catch (Exception ex)
        {         
            switch (ex)
            {
                case EntityNotFoundException ne:
                    response.StatusCode = (int)ne.StatusCode;
                    responseWrapper.Messages = ne.ErrorMessages!;
                    break;
                case ForbiddenException fe:
                    response.StatusCode = (int)fe.StatusCode;
                    responseWrapper.Messages = fe.ErrorMessages!;
                    break;
                case UnauthorizedException ue:
                    response.StatusCode = (int)ue.StatusCode;
                    responseWrapper.Messages = ue.ErrorMessages!;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseWrapper.Messages = [ex.Message];
                    break;
            }
            var result = JsonSerializer.Serialize(responseWrapper);
            await response.WriteAsync(result);
        }
    }
}
