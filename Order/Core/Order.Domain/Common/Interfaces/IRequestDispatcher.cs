namespace Order.Domain.Common.Interfaces;

public interface IRequestDispatcher
{
    Task<TResult> SendAsync<TResult>(IRequest<TResult> request);
}
