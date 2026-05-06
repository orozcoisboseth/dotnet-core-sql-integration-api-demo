// Demo ASP.NET Core API entry point
// This project is for demonstration purposes only
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DemoApi.Services;
var builder = WebApplication.CreateBuilder(args);

/*
 * =========================================================
 * Services registration
 * =========================================================
 */

// Controller support
builder.Services.AddControllers();

// Demo services
builder.Services.AddSingleton<ExternalTransactionService>();

var app = builder.Build();

/*
 * =========================================================
 * Middleware pipeline
 * =========================================================
 */

// Base path to simulate production API structure
app.UsePathBase("/api");

// Simple API key authentication (DEMO)
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.ContainsKey("x-api-key"))
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync("Unauthorized");
        return;
    }

    await next();
});

// Map controllers
app.MapControllers();

app.Run();
