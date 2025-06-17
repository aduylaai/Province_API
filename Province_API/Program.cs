using Microsoft.OpenApi.Models;
using Province_API.Application;
using Province_API.Application.Interfaces;
using Province_API.Application.Usecase;
using Province_API.Infrastructure;
using Province_API.Location.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddApplication();
builder.Services.AddInfrastructure();


builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Province API",
        Version = "v1"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
