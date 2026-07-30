using KittenRs.Components;
using KittenRs.Data;
using KittenRs.Services;
using Microsoft.EntityFrameworkCore;

namespace KittenRs;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();
        
        builder.Services.AddScoped(sp => new HttpClient());

        builder.Services.AddControllers();

        builder.Services.AddScoped<PostService>();
        
        
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        var serverVersion = new MariaDbServerVersion(new Version(11,4,12));
        builder.Services.AddDbContextFactory<ApplicationDbContext>(options => 
                options.UseMySql(connectionString,  serverVersion)
#if DEBUG
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
#endif
        );
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

        app.MapControllers();
        
        app.Run();
    }
}