using Asp.Versioning;
using Asp.Versioning.Builder;
using BuildingBlocks.Wrappers.http;
using Carter;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace Catalog.Api.Endpoints.V1;

public class ProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
                                     .HasApiVersion(new ApiVersion(1))
                                     .ReportApiVersions()
                                     .Build();

        RouteGroupBuilder groupBuilder = app.MapGroup("v{apiVersion:apiVersion}").WithApiVersionSet(apiVersionSet);

        groupBuilder.MapGet("products", async (HttpContext context, IProductService service) =>
        {
            if (!QueryParameterParser.TryParseQueryParameters(context.Request.Query, out var queryParams))
            {
                return Results.BadRequest("Invalid query parameters");
            }

            var response = await service.GetPagedAsync(queryParams);

            if (response.ISuccessful)
            {
                return Results.Ok(response);
            }
            return Results.BadRequest();
        });

        groupBuilder.MapGet("products/{id:int}", async (IProductService service, int id) =>
        {

            var response = await service.GetProductById(id);
            if (response.ISuccessful)
            {
                return Results.Ok(response);
            }
            return Results.BadRequest();
        });

        groupBuilder.MapPost("products", async (IValidator<CreateProductDto> validator, IProductService service, CreateProductDto productDto) =>
        {
            var result = await validator.ValidateAsync(productDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            var response = await service.Create(productDto);
            if (response.ISuccessful)
            {
                return Results.Created();
            }
            return Results.BadRequest();
        });

        groupBuilder.MapPut("products", async (IValidator<UpdateProductDto> validator, IProductService service, UpdateProductDto productDto) =>
        {
            var result = await validator.ValidateAsync(productDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            var response = await service.Update(productDto);
            if (response.ISuccessful)
            {
                return Results.NoContent();
            }
            return Results.BadRequest();
        });

        groupBuilder.MapDelete("products/{id:int}", async (IProductService service, int id) =>
        {
            await service.Delete(id);
            return Results.NoContent();
        });
    }
}
