using Carter;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}

app.UseHttpsRedirection();
app.MapCarter();

await app.RunAsync();
