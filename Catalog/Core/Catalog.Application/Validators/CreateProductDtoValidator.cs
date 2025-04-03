using Catalog.Application.DTOs;
using FluentValidation;

namespace Catalog.Application.Validators;

public class CreateProductDtoValidator: AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price must be greater than 0");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category id is required");
    }
}
