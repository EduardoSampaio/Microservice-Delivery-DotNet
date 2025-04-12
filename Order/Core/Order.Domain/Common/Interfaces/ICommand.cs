namespace Order.Domain.Common.Interfaces;

public struct Unit
{
    public static readonly Unit Value = new();
}

public interface ICommand : IRequest<Unit> { }

public interface ICommand<TResult> : IRequest<TResult> { }





