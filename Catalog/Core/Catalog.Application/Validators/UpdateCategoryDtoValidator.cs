using Catalog.Application.DTOs;
using FluentValidation;

namespace Catalog.Application.Validators;

public class UpdateCategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
    }
}
