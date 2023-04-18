using asteroid_fever.Application.Interfaces;
using asteroid_fever.Application.Services;
using asteroid_fever.Infrastructure.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://profivankov.github.io")
            .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
            .AllowAnyHeader();
        });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
    options.Filters.Add<LoggingActionFilter>();
});

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IImpactService, ImpactService>();

builder.Logging.ClearProviders().AddConsole();

var app = builder.Build();

app.UseCors("AllowClient");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
