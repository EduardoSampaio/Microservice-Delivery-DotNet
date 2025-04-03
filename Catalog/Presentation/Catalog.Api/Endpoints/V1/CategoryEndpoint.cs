using Asp.Versioning;
using Asp.Versioning.Builder;
using Carter;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using FluentValidation;

namespace Catalog.Api.Endpoints.V1;

public class CategoryEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
                                        .HasApiVersion(new ApiVersion(1))
                                        .ReportApiVersions()
                                        .Build();

        RouteGroupBuilder groupBuilder = app.MapGroup("api/v{apiVersion:apiVersion}").WithApiVersionSet(apiVersionSet);

        groupBuilder.MapGet("categories", async (ICategoryService service) =>
        {
            var response = await service.GetCategories();
            if (response.ISuccessful)
            {
                return Results.Ok(response);
            }

            return Results.BadRequest();
        });

        groupBuilder.MapGet("categories/{id:int}", async (ICategoryService service, int id) =>
        {
            var response = await service.GetCategoryById(id);
            if (response.ISuccessful)
            {
                return Results.Ok(response);
            }

            return Results.BadRequest();
        });

        groupBuilder.MapPost("categories", async (IValidator<CreateCategoryDto> validator, ICategoryService service, CreateCategoryDto categoryDto) =>
        {
            var result = await validator.ValidateAsync(categoryDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var response = await service.Create(categoryDto);
            if (response.ISuccessful)
            {
                return Results.Created();
            }

            return Results.BadRequest();
        });

        groupBuilder.MapPut("categories", async (IValidator<CategoryDto> validator,ICategoryService service, CategoryDto categoryDto) =>
        {
            var result = await validator.ValidateAsync(categoryDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var response = await service.Update(categoryDto);
            if (response.ISuccessful)
            {
                return Results.NoContent();
            }


            return Results.BadRequest();
        });

        groupBuilder.MapDelete("categories/{id:int}", async (ICategoryService service, int id) =>
        {
            await service.Delete(id);
            return Results.NoContent();
        });
    }
}
