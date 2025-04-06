using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

public class CacheMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CacheMiddleware> _logger;

    public CacheMiddleware(RequestDelegate next, ILogger<CacheMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, IDistributedCache cache)
    {
        if (context.Request.Method != HttpMethods.Get)
        {
            await _next(context);
            return;
        }

        var key = $"cache:{context.Request.Path}{context.Request.QueryString}";

        var cached = await cache.GetStringAsync(key);
        if (cached is not null)
        {
            _logger.LogInformation("✅ [CACHE HIT] {Key}", key);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(cached);
            return;
        }

        _logger.LogInformation("❌ [CACHE MISS] {Key}", key);

        var originalBody = context.Response.Body;
        using var memStream = new MemoryStream();
        context.Response.Body = memStream;

        await _next(context); // executa o proxy

        memStream.Seek(0, SeekOrigin.Begin);
        var body = await new StreamReader(memStream).ReadToEndAsync();

        await cache.SetStringAsync(key, body, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
        });

        memStream.Seek(0, SeekOrigin.Begin);
        await memStream.CopyToAsync(originalBody);
        context.Response.Body = originalBody;
    }
}
