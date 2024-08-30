using Blazor.Components;
using Blazor.Services;
using DomainModels;  // Import your DbContext namespace
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;  // Import for EF Core
using System.Net.NetworkInformation;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Get connection string from configuration or environment variable
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? Environment.GetEnvironmentVariable("DefaultConnection");

        // Configure ApplicationDbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));  // Use your DB provider, here PostgreSQL

        // Register other services
        builder.Services.AddSingleton<DatabaseService>(sp => new DatabaseService(connectionString!));

        // AuthenticationService Registration
        builder.Services.AddAuthentication("Cookies")
            .AddCookie("Cookies", options =>
            {
                // Configure your authentication options here
            });

        // Register AppState
        builder.Services.AddScoped<AppState>();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddHttpClient("API", client =>
        {
            client.BaseAddress = new Uri("https://localhost:7207/"); // Your API's URL
        });

        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
