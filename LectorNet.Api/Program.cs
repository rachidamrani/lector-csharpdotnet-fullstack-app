using LectorNet.Api;
using LectorNet.Application;
using LectorNet.Infrastructure;
using LectorNet.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddPresentation()
    .AddApplication()
    .AddInfrastructure(
        builder.Configuration.GetConnectionString("MySqlDefaultConnection")!,
        builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LectorNetDbContext>();
    if (!context.Books.Any() && !context.Users.Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo Api");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();