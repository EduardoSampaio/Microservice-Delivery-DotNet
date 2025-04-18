﻿using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace BuildingBlocks.Middleware
{
    /**
     * RequestLogContextMiddleware is a custom middleware that logs the details of incoming HTTP requests and their responses.
     * It uses Serilog's LogContext to add properties to the log context, such as CorrelationId, RequestId, RequestPath, and RequestMethod.
     * The middleware measures the time taken to process each request and logs the status code of the response.
     */
    public class RequestLogContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogContextMiddleware> _logger;

        public RequestLogContextMiddleware(RequestDelegate next, ILogger<RequestLogContextMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
            {
                var stopwatch = Stopwatch.StartNew();

                var request = context.Request;
                var requestId = Guid.NewGuid().ToString();

                LogContext.PushProperty("RequestId", requestId);
                LogContext.PushProperty("RequestPath", request.Path);
                LogContext.PushProperty("RequestMethod", request.Method);

                _logger.LogInformation("➡️  Starting request {Method} {Path}", request.Method, request.Path);
 
                await _next(context);

                stopwatch.Stop();

                var response = context.Response;
                var statusCode = response.StatusCode;

                _logger.LogInformation("✅  Completed request {Method} {Path} with status code {StatusCode} in {Elapsed:0.0000} ms",
                    request.Method,
                    request.Path,
                    statusCode,
                    stopwatch.Elapsed.TotalMilliseconds);
            }         
        }
    }
}
