using BuildingBlocks.Wrappers.http;
using Order.Application.Features.Baskets.Dtos;
using Order.Domain.Common.Interfaces;
using Order.Domain.Repositories;

namespace Order.Application.Features.Baskets.Command;

public class CreateBasketCheckoutCommand: ICommand
{
    public CreateBasketCheckoutDto CreateBasketCheckoutDto { get; set; }

    public CreateBasketCheckoutCommand(CreateBasketCheckoutDto createBasketCheckoutDto)
    {
        CreateBasketCheckoutDto = createBasketCheckoutDto;
    }
}

public class CreateBasketCheckoutCommandHandler(IBasketCheckoutRepository basketCheckoutRepository)
    : IRequestHandler<CreateBasketCheckoutCommand, IResponseWrapper>
{
    public async Task<IResponseWrapper> HandleAsync(CreateBasketCheckoutCommand command)
    {
        var entity = command.CreateBasketCheckoutDto.ToEntity();
        await basketCheckoutRepository.AddAsync(entity);
        return await ResponseWrapper.SuccessAsync();
    }
}
