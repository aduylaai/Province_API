using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Province_API.Core.Application;
using Province_API.Infrastructure;
using Province_API.Infrastructure.Data;
using Province_API.Infrastructure.Utils;
using Province_API.Usecase;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddControllers();


builder.Services.AddApplication();
builder.Services.AddUseCase();
builder.Services.AddInfrastructure(connectionString);



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


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();

    var seeder = scope.ServiceProvider.GetRequiredService<JsonSeeder>();
    seeder.Seed();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
