using BuildingBlocks.Wrappers.http;

namespace Order.Domain.Common.Interfaces;

public interface IRequestHandler<TRequest, TResult> where TRequest : IRequest<IResponseWrapper>
{
    Task<TResult> HandleAsync(TRequest request);
}




