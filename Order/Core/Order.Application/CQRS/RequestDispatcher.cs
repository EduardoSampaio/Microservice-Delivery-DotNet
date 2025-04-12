using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Order.Domain.Common.Interfaces;

namespace Order.Application.CQRS;

public class RequestDispatcher : IRequestDispatcher
{
    private readonly IServiceProvider _provider;
    private readonly ILogger<RequestDispatcher> _logger;

    public RequestDispatcher(IServiceProvider provider, ILogger<RequestDispatcher> logger)
    {
        _provider = provider;
        _logger = logger;
    }

    public async Task<TResult> SendAsync<TResult>(IRequest<TResult> request)
    {
        _logger.LogInformation("Executando request: {RequestType}", request.GetType().Name);

        await ValidateAsync(request);

        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResult));
        dynamic handler = _provider.GetRequiredService(handlerType);
        return await handler.HandleAsync((dynamic)request);
    }

    private async Task ValidateAsync<T>(T request)
    {
        var validator = _provider.GetService<IValidator<T>>();
        if (validator is not null)
        {
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                _logger.LogWarning("Validação falhou para {RequestType}: {Errors}", typeof(T).Name, errors);
                throw new ValidationException(result.Errors);
            }
        }
    }
}

