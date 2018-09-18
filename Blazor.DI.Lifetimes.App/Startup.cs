using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.DI.Lifetimes.App.Services;

namespace Blazor.DI.Lifetimes.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service
            // to read the forecast data.
            services.AddSingleton<WeatherForecastService>();

            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");

            app.Services.GetService<SingletonService>().Counter++;
            app.Services.GetService<ScopedService>().Counter++;
            app.Services.GetService<TransientService>().Counter++;
        }
    }
}
