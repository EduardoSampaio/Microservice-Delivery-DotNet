namespace Order.Application.Features.Baskets.Validators;
using FluentValidation;
using Order.Application.Features.Baskets.Command;

public class CreateBasketCheckoutDtoValidator: AbstractValidator<CreateBasketCheckoutCommand>
{
    public CreateBasketCheckoutDtoValidator()
    {
        RuleFor(x => x.CreateBasketCheckoutDto.CustomerId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Customer Id is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.CustomerEmail)
           .NotNull().WithMessage("Customer Email is required.")
           .NotEmpty().WithMessage("Customer Email is required.")
           .EmailAddress().WithMessage("Customer Email is not valid.");

        RuleFor(x => x.CreateBasketCheckoutDto.CustomerName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Customer Name is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.CustomerPhone).NotNull()
            .NotEmpty()
            .WithMessage("Customer Phone is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.AddressLine)
            .NotEmpty()
            .NotNull()
            .WithMessage("Address Line is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.Country)
            .NotEmpty()
            .NotNull()
            .WithMessage("Country is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.State)
            .NotEmpty()
            .NotNull()
            .WithMessage("State is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.ZipCode)
            .NotEmpty()
            .NotNull()
            .WithMessage("Zip Code is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.CardName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Card Name is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.CardNumber)
            .NotEmpty()
            .NotNull()
            .WithMessage("Card Number is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.Expiration)
            .NotEmpty()
            .NotNull()
            .WithMessage("Expiration is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.Cvv)
            .NotEmpty()
            .NotNull()
            .WithMessage("CVV is required.");

        RuleFor(x => x.CreateBasketCheckoutDto.PaymentMethod)
            .NotEmpty()
            .NotNull()
            .WithMessage("Payment Method is required.")
            .IsInEnum()
            .WithMessage("Payment Method is not valid.");

    }
}
