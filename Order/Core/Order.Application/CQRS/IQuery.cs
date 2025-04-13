using BuildingBlocks.Wrappers.http;

namespace Order.Domain.Common.Interfaces;
public interface IQuery<IResponseWrapper> : IRequest<IResponseWrapper> { }
