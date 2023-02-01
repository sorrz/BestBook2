using BestBook2.Data;
using BestBook2.Options;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

public class Program
{
    public static IConfiguration Configuration { get; set; }
    public static async Task Main(string[] args)
    {
        //Create Builder
        var builder = WebApplication.CreateBuilder(args);

        var b = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

        Configuration = b.Build();

        // Add Options to Container
        ConfigureOptions(builder.Services);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddHttpClient();
        builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer("DefaultConnection"));


        builder.Services.AddTransient<ICall, Call>();

        #region testing
        builder.Services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" });
        });
        // Server Side Blazor doesn't register HttpClient by default
        if (!builder.Services.Any(x => x.ServiceType == typeof(HttpClient)))
        {
            // Setup HttpClient for server side in a client side compatible fashion
            builder.Services.AddScoped<HttpClient>(s =>
            {
                // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it. 
                var uriHelper = s.GetRequiredService<NavigationManager>();
                return new HttpClient
                {
                    BaseAddress = new Uri(uriHelper.BaseUri)
                };
            });
        }
        #endregion



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // App Additions
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();


    }

    public static void ConfigureOptions(IServiceCollection services)
    {
        services.Configure<SqlDbOptions>(Configuration.GetSection("ConnectionStrings"));
        
    }
}