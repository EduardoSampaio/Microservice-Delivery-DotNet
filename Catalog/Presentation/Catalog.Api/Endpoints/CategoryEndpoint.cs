using Carter;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;

namespace Catalog.Api.Endpoints;

public class CategoryEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/categories", async (ICategoryService service) =>
        {
            var response = await service.GetCategories();
            if (response.ISuccessful)
            {
                return Results.Ok(response);
            }

            return Results.BadRequest();
        });

        app.MapGet("/api/categories/{id:int}", async (ICategoryService service, int id) =>
        {
            var response = await service.GetCategoryById(id);
            if (response.ISuccessful)
            {
                return Results.Ok(response);
            }

            return Results.BadRequest();
        });

        app.MapPost("/api/categories", async (ICategoryService service, CreateCategoryDto categoryDto) =>
        {
            var response = await service.Create(categoryDto);
            if (response.ISuccessful)
            {
                return Results.Created();
            }

            return Results.BadRequest();
        });

        app.MapPut("/api/categories", async (ICategoryService service, CategoryDto categoryDto) =>
        {
            var response = await service.Update(categoryDto);
            if (response.ISuccessful)
            {
                return Results.NoContent();
            }


            return Results.BadRequest();
        });

        app.MapDelete("/api/categories/{id:int}", async (ICategoryService service, int id) =>
        {
            await service.Delete(id);
            return Results.NoContent();
        });
    }
}
