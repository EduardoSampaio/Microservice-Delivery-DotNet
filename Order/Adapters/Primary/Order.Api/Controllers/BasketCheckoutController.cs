using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.Baskets.Command;
using Order.Application.Features.Baskets.Dtos;
using Order.Domain.Common.Interfaces;


namespace Order.Api.Controllers;

[ApiController]
[Route("basket-checkout")]
public class BasketCheckoutController : ControllerBase
{
    private readonly IRequestDispatcher _requestDispatcher;

    public BasketCheckoutController(IRequestDispatcher requestDispatcher)
    {
        _requestDispatcher = requestDispatcher;
    }


    [HttpPost]
    public async Task<IActionResult> Checkout([FromBody] CreateBasketCheckoutDto createBasketCheckoutDto)
    {
        var response = await _requestDispatcher.SendAsync(new CreateBasketCheckoutCommand(createBasketCheckoutDto));
        if (response.ISuccessful)
        {
            return Ok();
        }
        return BadRequest();
    }
}
