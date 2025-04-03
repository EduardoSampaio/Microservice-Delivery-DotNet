using Asp.Versioning;
using BuildingBlocks.Middleware;
using Carter;
using Catalog.Infrastructure.Data;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddHealthChecks()
                .AddNpgSql(connectionString, "SELECT 1;")
                .AddDbContextCheck<AppDbContext>();

builder.Services.AddHealthChecksUI(opt =>
{
    opt.SetEvaluationTimeInSeconds(10); //time in seconds between check    
    opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks    
    opt.SetApiMaxActiveRequests(1); //api requests concurrency    
    opt.AddHealthCheckEndpoint("feedback api", "/api/health"); //map health check api    

}).AddInMemoryStorage();


builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-ApiVersion"));
});

builder.Services.AddCarter();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHealthChecks("/api/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options => options.UIPath = "/health-ui");

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapCarter();

await app.RunAsync();
